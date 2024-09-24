namespace PersonalFinanceAssistant.Entities;

public sealed class User : Resource
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public List<Account> Accounts { get; set; }
    public List<Budget> Budgets { get; set; }
}