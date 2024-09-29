using Application.Dtos;
using AutoMapper;
using Infrastructure.Data;
using PersonalFinanceAssistant.Entities;

namespace PersonalFinanceAssistant.Services;

public class UserService : IUserService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public UserService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public bool UpdateUserName(Guid userId, string userName)
    {
        // Find the user by userId in the database
        var userEntity = _context.Users.FirstOrDefault(u => u.Id == userId);

        if (userEntity == null)
        {
            return false; // User not found
        }

        // Update the UserName field with the new value
        userEntity.UserName = userName;

        // Save changes to the database
        _context.SaveChanges();

        return true;
    }

    public bool UpdateEmail(string email)
    {
        throw new NotImplementedException();
    }

    public bool UpdateEmail(Guid userId, string email)
    {
        // Find the user by userId in the database
        var userEntity = _context.Users.FirstOrDefault(u => u.Id == userId);

        if (userEntity == null)
        {
            return false; // User not found
        }

        // Update the Email field with the new value
        userEntity.Email = email;

        // Save changes to the database
        _context.SaveChanges();

        return true;
    }

    public bool DeleteAccount(Guid userId, Guid accountId)
    {
        var userEntity = _context.Users.FirstOrDefault(u => u.Id == userId);
        var accountEntity = _context.Accounts.FirstOrDefault(a => a.Id == accountId);
        
        if (userEntity == null || accountEntity == null)
        {
            return false;
        }


        userEntity.Accounts.Remove(accountEntity);
        
        //might be an issue here
        _context.Accounts.Remove(accountEntity);

        _context.SaveChanges();

        return true;
    }

    public bool DeleteBudget(Guid userId, Guid budgetId)
    {
        var userEntity = _context.Users.FirstOrDefault(u => u.Id == userId);
        var budgetEntity = _context.Budgets.FirstOrDefault(a => a.Id == budgetId);
        
        if (userEntity == null || budgetEntity == null)
        {
            return false;
        }
        
        userEntity.Budgets.Remove(budgetEntity);
        
        //might be an issue here
        _context.Budgets.Remove(budgetEntity);

        _context.SaveChanges();

        return true;
    }

    public bool AddAccount(Guid userId ,AccountDto accountDto)
    {
        var userEntity = _context.Users.FirstOrDefault(u => u.Id == userId);
        
        if (userEntity == null)
        {
            return false;
        }
        
        // Map the DTO to the entity using AutoMapper
        var accountEntity = _mapper.Map<Account>(accountDto);
        accountEntity.Id = Guid.NewGuid(); // Assign a new ID

        // Add the account to the database
        _context.Accounts.Add(accountEntity);
        
        userEntity.Accounts.Add(accountEntity);
        
        // Save changes
        _context.SaveChanges();

        return true;
    }

    public bool AddBudget(Guid userId, BudgetDto budgetDto)
    {
        var userEntity = _context.Users.FirstOrDefault(u => u.Id == userId);

        if (userEntity == null)
        {
            return false;
        }
        
        // Map the DTO to the entity using AutoMapper
        var budgetEntity = _mapper.Map<Budget>(budgetDto);
        budgetEntity.Id = Guid.NewGuid(); // Assign a new ID

        // Add the budget to the database
        _context.Budgets.Add(budgetEntity);

        userEntity.Budgets.Add(budgetEntity);
        
        // Save changes
        _context.SaveChanges();

        return true;
    }
}