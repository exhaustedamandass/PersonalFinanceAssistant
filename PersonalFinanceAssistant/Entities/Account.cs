namespace PersonalFinanceAssistant.Entities;

public sealed class Account : Resource
{
    public string Id { get; set; }
    public string Name { get; set; }
    public decimal Balance { get; set; }
    public List<Transaction> Transactions { get; set; }
}