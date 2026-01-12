using Models;
using DTOs.Transactions;
using Microsoft.EntityFrameworkCore;

namespace Endpoints
{
    public static class TransactionEndpoints
    {
        public static void AddTransactionEndpoints(this WebApplication app)
        {
            
        }

        public static async Task<IResult> CreateTransaction(CreateTransactionRequest request, AppDbContext db)
        {
            return TypedResults.Ok();
        }
    }
}