using PersonalFinanceAssistant.Entities;

namespace PersonalFinanceAssistant.Services;

public interface IAccountService
{
    void UpdateAccountName(string newAccountName);

    void UpdateAccountBalance(decimal newBalanceValue);

    void ChangeBalance(decimal changeValue);

    Task<List<Transaction>> GetAllTransactionsAsync(string accountId);

    Task<List<Account>> GetAllAccountsAsync();

    void AddTransaction(Transaction newTransaction);

    void CreateNewAccount(Account account);
}