using PersonalFinanceAssistant.Entities;

namespace PersonalFinanceAssistant.Services;

public class TransactionService : ITransactionService
{
    public Task<List<Transaction>> GetTransactionsAsync(string userId)
    {
        throw new NotImplementedException();
    }

    public Task<Transaction> GetSingleTransactionAsync(string transactionId)
    {
        throw new NotImplementedException();
    }

    public void DeleteTransaction(string transactionId)
    {
        throw new NotImplementedException();
    }

    public void UpdateTransaction(string transactionId, Transaction newTransaction)
    {
        throw new NotImplementedException();
    }

    public void CreateTransaction(Transaction newTransaction)
    {
        throw new NotImplementedException();
    }
}