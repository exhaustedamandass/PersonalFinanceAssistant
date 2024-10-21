namespace Application.Dtos;

public class TransactionDto
{
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public string TransactionType { get; set; }
    public string Recipient { get; set; }
    public int AccountId { get; set; }
}