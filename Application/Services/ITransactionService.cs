using PersonalFinanceAssistant.Entities;

namespace PersonalFinanceAssistant.Services;

public interface ITransactionService
{
    Task<List<Transaction>> GetTransactionsAsync(string userId);

    Task<Transaction> GetSingleTransactionAsync(string transactionId);

    void DeleteTransaction(string transactionId);

    void UpdateTransaction(string transactionId, Transaction newTransaction);

    void CreateTransaction(Transaction newTransaction);
}