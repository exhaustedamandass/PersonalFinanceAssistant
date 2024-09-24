namespace PersonalFinanceAssistant.Entities;

public sealed class Report
{
    public DateTime StartDate { get; set; } // Start date of the report period
    public DateTime EndDate { get; set; } // End date of the report period
    public List<Transaction> Transactions { get; set; } // List of transactions for the report period
    public decimal TotalIncome { get; set; } // Total income during the report period
    public decimal TotalExpenses { get; set; } // Total expenses during the report period
    public Dictionary<string, decimal> SpendingByCategory { get; set; }
}