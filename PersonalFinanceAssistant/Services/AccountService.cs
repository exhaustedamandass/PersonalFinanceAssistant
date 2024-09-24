using PersonalFinanceAssistant.Entities;

namespace PersonalFinanceAssistant.Services;

public class AccountService : IAccountService
{
    public void UpdateAccountName(string newAccountName)
    {
        throw new NotImplementedException();
    }

    public void UpdateAccountBalance(decimal newBalanceValue)
    {
        throw new NotImplementedException();
    }

    public void ChangeBalance(decimal changeValue)
    {
        throw new NotImplementedException();
    }

    public Task<List<Transaction>> GetAllTransactionsAsync(string accountId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Account>> GetAllAccountsAsync()
    {
        throw new NotImplementedException();
    }

    public void AddTransaction(Transaction newTransaction)
    {
        throw new NotImplementedException();
    }

    public void CreateNewAccount(Account account)
    {
        throw new NotImplementedException();
    }
}