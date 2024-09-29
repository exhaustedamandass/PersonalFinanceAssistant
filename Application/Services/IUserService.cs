using Application.Dtos;
using PersonalFinanceAssistant.Entities;

namespace PersonalFinanceAssistant.Services;

public interface IUserService
{
    public bool UpdateUserName(Guid userId, string userName);

    public bool UpdateEmail(Guid userId, string userName);

    public bool DeleteAccount(Guid userId, Guid accountId);

    public bool DeleteBudget(Guid userId, Guid budgetId);

    public bool AddAccount(Guid userId ,AccountDto accountDto);

    public bool AddBudget(Guid userId ,BudgetDto account);
}