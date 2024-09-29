using Application.Dtos;
using Application.Mappers;
using AutoMapper;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceAssistant.Entities;

namespace PersonalFinanceAssistant.Services;

public class AccountService : IAccountService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public AccountService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public void UpdateAccountName(Guid accountId, string newAccountName)
    {
        // Fetch the account by accountId
        var account = _context.Accounts.Find(accountId);
        if (account == null)
        {
            throw new KeyNotFoundException($"Account with ID {accountId} not found.");
        }

        // Update the account name
        account.Name = newAccountName; // Assuming there's a Name property in Account
        
        // Save changes to the database
        _context.SaveChanges();
    }
    
    public void AddTransaction(Guid accountId, TransactionDto transactionDto)
    {
        var account = _context.Accounts.Find(accountId);
        if (account == null)
        {
            throw new KeyNotFoundException($"Account with ID {accountId} not found.");
        }

        // Map the TransactionDto to the Transaction entity
        var transaction = _mapper.Map<Transaction>(transactionDto);
        
        // Associate the transaction with the account
        transaction.AccountId = accountId; // Assuming there's an AccountId property in Transaction
        
        // Add the transaction to the context
        _context.Transactions.Add(transaction);
        
        // Save changes to the database
        _context.SaveChanges();
    }
    
    public void UpdateAccountBalance(decimal newBalanceValue)
    {
        throw new NotImplementedException();
    }

    public void ChangeBalance(decimal changeValue)
    {
        throw new NotImplementedException();
    }

    public List<Transaction> GetAllTransactions(string accountId)
    {
        throw new NotImplementedException();
    }

    public List<Transaction>? GetAllTransactions(Guid accountId)
    {
        // Retrieve the account along with its related transactions
        var account = _context.Accounts
            .Include(a => a.Transactions) // Load related transactions
            .FirstOrDefault(a => a.Id == accountId);

        return account?.Transactions;
    }

    public List<Account> GetAllAccounts()
    {
        return _context.Accounts.ToList();
    }


    public bool CreateNewAccount(AccountDto accountDto)
    {
        var existingAccount = _context.Accounts.Any(a => a.Name == accountDto.AccountName);
        if (existingAccount) return false;
        
        var account = _mapper.Map<Account>(accountDto);

        try
        {
            _context.Accounts.Add(account);  // Add the new account
            _context.SaveChanges();          // Save to the database
            return true;                     // Account created successfully
        }
        catch (Exception)
        {
            return false;  // Indicate failure due to an internal error
        }
    }
    
    public bool IsDuplicateAccount(AccountDto accountDto)
    {
        // Check for duplicates based on the Name or any other condition
        return _context.Accounts.Any(a => a.Name == accountDto.AccountName);
    }
}