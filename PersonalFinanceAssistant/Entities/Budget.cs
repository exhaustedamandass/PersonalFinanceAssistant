namespace PersonalFinanceAssistant.Entities;

public sealed class Budget : Resource
{
    public string BudgetId { get; set; }
    public BudgetCategories Category { get; set; } 
    public decimal Limit { get; set; } 
    public decimal Spent { get; set; } 
    public DateTime PeriodStart { get; set; } 
    public DateTime PeriodEnd { get; set; } 
}