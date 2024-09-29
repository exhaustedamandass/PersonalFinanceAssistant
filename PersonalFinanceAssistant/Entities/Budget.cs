using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalFinanceAssistant.Entities;

public sealed class Budget : Resource
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public BudgetCategories Category { get; set; } 
    public decimal Limit { get; set; } 
    public decimal Spent { get; set; } 
    public DateTime PeriodStart { get; set; } 
    public DateTime PeriodEnd { get; set; } 
}