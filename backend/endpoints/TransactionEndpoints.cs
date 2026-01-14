using Models;
using DTOs.Transactions;
using Microsoft.EntityFrameworkCore;

namespace Endpoints
{
    public static class TransactionEndpoints
    {
        public static void AddTransactionEndpoints(this WebApplication app)
        {
            app.MapPost("/transaction", CreateTransaction);
        }

        public static async Task<IResult> CreateTransaction(CreateTransactionRequest request, AppDbContext db)
        {
            var transactionEntity = new Transaction
            {
                Date = request.Date,
                Description = request.Description,
                Amount = request.Amount,
                AccountId = request.AccountId,
                CategoryId = request.CategoryId
            };

            db.Transactions.Add(transactionEntity);
            await db.SaveChangesAsync();
            /*
             *System.NullReferenceException: 'Object reference not set to an instance of an object.'

Models.Transaction.Account.get returned null.
            */
            return TypedResults.Created(
                $"/Category/{transactionEntity.Id}",
                new TransactionResponse(
                    transactionEntity.Id,
                    transactionEntity.Date,
                    transactionEntity.Description,
                    transactionEntity.Amount
                    )
                );
        }
    }
}