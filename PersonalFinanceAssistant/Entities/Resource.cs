namespace PersonalFinanceAssistant.Entities;

public abstract class Resource : Link
{
    public Link Self { get; set; }
}