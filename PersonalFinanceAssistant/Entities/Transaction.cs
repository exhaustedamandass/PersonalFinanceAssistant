﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalFinanceAssistant.Entities;

public sealed class Transaction
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; } 
    public DateTime Date { get; set; }
    public string Description { get; set; } 
    public decimal Amount { get; set; } 
    public TransactionType Type { get; set; }
    public Guid CategoryId { get; set; }
    public Guid AccountId { get; set; } 
}