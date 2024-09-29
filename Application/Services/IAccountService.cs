using Application.Dtos;
using PersonalFinanceAssistant.Entities;

namespace PersonalFinanceAssistant.Services;

public interface IAccountService
{
    void UpdateAccountName(Guid accountId, string newAccountName);

    void UpdateAccountBalance(decimal newBalanceValue);

    void ChangeBalance(decimal changeValue);

    List<Transaction>? GetAllTransactions(Guid accountId);

    List<Account> GetAllAccounts();

    void AddTransaction(Guid accountId, TransactionDto transactionDto);

    bool CreateNewAccount(AccountDto account);
    
    public bool IsDuplicateAccount(AccountDto accountDto);
}