namespace PersonalFinanceAssistant.Entities;

public sealed class Transaction : Resource
{
    public string Id { get; set; } 
    public DateTime Date { get; set; }
    public string Description { get; set; } 
    public decimal Amount { get; set; } 
    public TransactionType Type { get; set; }
    public string CategoryId { get; set; }
    public string AccountId { get; set; } 
}