using PersonalFinanceAssistant.Entities;

namespace PersonalFinanceAssistant.Services;

public interface IBudgetService
{
    void UpdateLimit(decimal newLimit);

    void UpdateSpent(decimal newSpent);

    void UpdateCategoryId(BudgetCategories newCategory);

    void UpdatePeriodStart(DateTime newStartPeriod);

    void UpdatePeriodEnd(DateTime newEndPeriod);

    void CreateNewBudget(BudgetCategories budgetCategory, decimal limit, DateTime periodStart,
        DateTime periodEnd);

    void DeleteBudget(string budgetId);

    void AddBudgetCategory(string newBudgetCategory);

    public Budget GetBudget(string budgetId);
}