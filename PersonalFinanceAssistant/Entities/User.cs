using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalFinanceAssistant.Entities;

public sealed class User 
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public List<Account> Accounts { get; set; }
    public List<Budget> Budgets { get; set; }
}