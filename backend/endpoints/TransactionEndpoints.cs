using Models;
using DTOs;
using Microsoft.EntityFrameworkCore;

namespace Endpoints
{
    public static class TransactionEndpoints
    {
        public static void AddTransactionEndpoints(this WebApplication app)
        {
            app.MapPost("/transaction/", CreateTransaction);
            app.MapGet("/transaction/{id}", GetTransaction);
        }

// broken
        // public static async Task<IResult> CreateTransaction(TransactionDTO transactionDTO, AppDbContext db)
        // {
        //     var transaction = new Transaction
        //     {
        //         Date = transactionDTO.Date,
        //         Description = transactionDTO.Description,
        //         Amount = transactionDTO.Amount,
        //         AccountID = transactionDTO.Date,
        //     }

        //     const returnTransaction = new TransactionDTO(transaction);
        //     return returnTransaction;
        // }

        public static async Task<IResult> GetTransaction(int Id, AppDbContext db)
        {
            return await db.Transactions.FindAsync(Id)
                is Transaction transaction
                    ? Results.Ok(new TransactionDTO(transaction))
                    : Results.NotFound();

        }
    }
}