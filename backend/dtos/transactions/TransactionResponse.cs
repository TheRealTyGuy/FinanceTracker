namespace DTOs.Transactions;

public record TransactionResponse(int Id, DateTime Date, string Description, decimal Amount, string AccountName, string CategoryName);