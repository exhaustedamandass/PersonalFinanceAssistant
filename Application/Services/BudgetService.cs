using PersonalFinanceAssistant.Entities;

namespace PersonalFinanceAssistant.Services;

public class BudgetService : IBudgetService
{
    public void UpdateLimit(decimal newLimit)
    {
        throw new NotImplementedException();
    }

    public void UpdateSpent(decimal newSpent)
    {
        throw new NotImplementedException();
    }

    public void UpdateCategoryId(BudgetCategories newCategory)
    {
        throw new NotImplementedException();
    }

    public void UpdatePeriodStart(DateTime newStartPeriod)
    {
        throw new NotImplementedException();
    }

    public void UpdatePeriodEnd(DateTime newEndPeriod)
    {
        throw new NotImplementedException();
    }

    public void CreateNewBudget(BudgetCategories budgetCategory, decimal limit, DateTime periodStart, DateTime periodEnd)
    {
        throw new NotImplementedException();
    }

    public void DeleteBudget(string budgetId)
    {
        throw new NotImplementedException();
    }

    public void AddBudgetCategory(string newBudgetCategory)
    {
        throw new NotImplementedException();
    }

    public Budget GetBudget(string budgetId)
    {
        throw new NotImplementedException();
    }
}