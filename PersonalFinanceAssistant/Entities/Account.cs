using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalFinanceAssistant.Entities;

public sealed class Account
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Balance { get; set; }
    public List<Transaction>? Transactions { get; set; }
    // Foreign key to the User entity
    public Guid UserId { get; set; } // Foreign key to the User entity

    // Navigation property for the related User entity
    public User User { get; set; } // The user that owns the account
}