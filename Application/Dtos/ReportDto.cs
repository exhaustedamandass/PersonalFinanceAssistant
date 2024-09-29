namespace Application.Dtos;

public class ReportDto
{
    public Guid UserId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal TotalIncome { get; set; } 
    public decimal TotalExpenses { get; set; } 
    public Dictionary<string, decimal> SpendingByCategory { get; set; }

}