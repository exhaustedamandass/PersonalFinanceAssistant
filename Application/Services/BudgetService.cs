using Application.Dtos;
using AutoMapper;
using Infrastructure.Data;
using PersonalFinanceAssistant.Entities;
using PersonalFinanceAssistant.Utilities;

namespace PersonalFinanceAssistant.Services;

public class BudgetService : IBudgetService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public BudgetService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public Budget? GetBudget(Guid budgetId)
    {
        var budgetEntity = _context.Budgets.FirstOrDefault(b => b.Id == budgetId);

        if (budgetEntity == null)
        {
            return null; // Not found
        }

        // Map the entity to a Budget DTO or model
        var budget = _mapper.Map<Budget>(budgetEntity);
        
        return budget;
    }

    public bool UpdateLimit(Guid budgetId, BudgetDto budgetDto)
    {
        var budgetEntity = _context.Budgets.FirstOrDefault(b => b.Id == budgetId);

        if (budgetEntity == null)
        {
            return false; // Budget not found
        }

        // Update the budget limit
        budgetEntity.Limit = budgetDto.Limit;

        // Save changes to the database
        _context.SaveChanges();
        
        return true;
    }

    public bool UpdateSpent(Guid budgetId, BudgetDto budgetDto)
    {
        var budgetEntity = _context.Budgets.FirstOrDefault(b => b.Id == budgetId);

        if (budgetEntity == null)
        {
            return false; // Budget not found
        }

        // Update the spent amount
        budgetEntity.Spent = budgetDto.Spent;

        // Save changes to the database
        _context.SaveChanges();
        
        return true;
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

    public bool CreateNewBudget(BudgetDto budgetDto)
    {
        var budgetCategory = BudgetCategoriesUtilities.Parse(budgetDto.Category);

        if (budgetCategory == null)
        {
            // If category parsing fails, return false to indicate failure
            return false;
        }

        var newBudget = new Budget
        {
            Id = Guid.NewGuid(),
            Category = budgetCategory.Value,
            Limit = budgetDto.Limit,
            Spent = 0,
            PeriodStart = budgetDto.PeriodStart,
            PeriodEnd = budgetDto.PeriodEnd
        };

        _context.Budgets.Add(newBudget);
        _context.SaveChanges();

        return true;    }

    public bool DeleteBudget(Guid budgetId)
    {
        // Find the budget by ID
        var budgetEntity = _context.Budgets.FirstOrDefault(b => b.Id == budgetId);

        if (budgetEntity == null)
        {
            return false; // Budget not found
        }

        // Remove the budget from the context
        _context.Budgets.Remove(budgetEntity);

        // Save changes to the database
        _context.SaveChanges();

        return true;
    }

    public void AddBudgetCategory(string newBudgetCategory)
    {
        throw new NotImplementedException();
    }

}