using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalFinanceAssistant.Entities;

public sealed class Budget
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public BudgetCategories Category { get; set; } 
    public decimal Limit { get; set; } 
    public decimal Spent { get; set; } 
    public DateTime PeriodStart { get; set; } 
    public DateTime PeriodEnd { get; set; } 
    // Foreign key to the User entity
    public Guid UserId { get; set; } // Foreign key to the User entity

    // Navigation property for the related User entity
    public User User { get; set; } // The user that owns the budget
}