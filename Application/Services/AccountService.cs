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

    public List<Transaction> GetAllTransactions(string accountId)
    {
        throw new NotImplementedException();
    }

    public List<Transaction>? GetAllTransactions(int accountId)
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

    public void AddTransaction(Transaction newTransaction)
    {
        throw new NotImplementedException();
    }

    public bool CreateNewAccount(AccountDto accountDto)
    {
        var existingAccount = _context.Accounts.Any(a => a.Name == accountDto.Name);
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
        return _context.Accounts.Any(a => a.Name == accountDto.Name);
    }
}