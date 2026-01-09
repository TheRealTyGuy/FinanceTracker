using Models;
using DTOs.Accounts;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace Endpoints
{
    public static class AccountEndpoints
    {
        public static void AddAccountEndpoints(this WebApplication app)
        {
            app.MapPost("/account", CreateAccount).RequireAuthorization();
            app.MapGet("/account", GetAccounts).RequireAuthorization();
        }

        public static async Task<IResult> CreateAccount(CreateAccountRequest request, AppDbContext db, ClaimsPrincipal user)
        {
            var currUserId = user.FindFirstValue(ClaimTypes.NameIdentifier);

            if (currUserId is null)
            {
                return TypedResults.Unauthorized();
            }

            var accountEntity = new Account
            {
                CurrencyType = request.CurrencyType,
                Name = request.Name,
                UserId = currUserId
            };

            db.Accounts.Add(accountEntity);
            await db.SaveChangesAsync();

            return TypedResults.Created(
                $"account/{accountEntity.Id}", 
                new AccountResponse(
                    accountEntity.Id,
                    accountEntity.CurrencyType,
                    accountEntity.Name
                )
            );
        }

        public static async Task<IResult> GetAccounts(AppDbContext db, ClaimsPrincipal user)
        {
            var currUserId = user.FindFirstValue(ClaimTypes.NameIdentifier);

            if (currUserId is null)
            {
                return TypedResults.Unauthorized();
            }

            var accounts = db.Accounts
                .Where(a => a.UserId == currUserId)
                .ToListAsync();    

            return TypedResults.Ok(accounts);
        } 
    }
}