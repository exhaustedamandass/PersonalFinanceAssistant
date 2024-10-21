namespace Application.Dtos;

public class BudgetDto
{
    public string Category { get; set; }
    public decimal Limit { get; set; }
    public decimal Spent { get; set; }
    public DateTime PeriodStart { get; set; }
    public DateTime PeriodEnd { get; set; }
}