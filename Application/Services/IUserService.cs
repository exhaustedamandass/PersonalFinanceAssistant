using PersonalFinanceAssistant.Entities;

namespace PersonalFinanceAssistant.Services;

public interface IUserService
{
    public void UpdateUserName(string userName);

    public void UpdateEmail(string email);

    public void DeleteAccount(string accountId);

    public void DeleteBudget(string budgetId);

    public void AddAccount(Account account);

    public void AddBudget(Budget budget);
}