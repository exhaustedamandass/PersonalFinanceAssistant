using Application.Dtos;
using PersonalFinanceAssistant.Entities;

namespace PersonalFinanceAssistant.Services;

public interface IAccountService
{
    void UpdateAccountName(string newAccountName);

    void UpdateAccountBalance(decimal newBalanceValue);

    void ChangeBalance(decimal changeValue);

    List<Transaction>? GetAllTransactions(int accountId);

    List<Account> GetAllAccounts();

    void AddTransaction(Transaction newTransaction);

    bool CreateNewAccount(AccountDto account);
    
    public bool IsDuplicateAccount(AccountDto accountDto);
}