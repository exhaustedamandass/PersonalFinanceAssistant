using Application.Dtos;
using PersonalFinanceAssistant.Entities;

namespace PersonalFinanceAssistant.Services;

public interface IBudgetService
{
    bool UpdateLimit(Guid budgetId, BudgetDto budgetDto);

    bool UpdateSpent(Guid budgetId, BudgetDto budgetDto);

    void UpdateCategoryId(BudgetCategories newCategory);

    void UpdatePeriodStart(DateTime newStartPeriod);

    void UpdatePeriodEnd(DateTime newEndPeriod);

    bool CreateNewBudget(BudgetDto budgetDto);

    bool DeleteBudget(Guid budgetId);

    void AddBudgetCategory(string newBudgetCategory);

    public Budget? GetBudget(Guid budgetId);
}