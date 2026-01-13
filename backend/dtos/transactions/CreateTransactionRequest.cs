namespace DTOs.Transactions;

// Need to figure out how to do the category relationship
// Should I have the frontend supply a CategoryID?
// Referencing account endpoints, I think I have to have them supply it or get it myself.
// I think I should make the frontend pass an account ID but idk
public record CreateTransactionRequest(DateTime Date, string Description, decimal Amount, int AccountId, int CategoryId);