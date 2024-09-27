using Microsoft.EntityFrameworkCore;
using PersonalFinanceAssistant.Entities;

namespace Infrastructure.Data;

public class DataContext : DbContext
{
    public DataContext (DbContextOptions<DataContext> options) : base (options) { }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<Budget> Budgets { get; set; }
    public DbSet<Report> Reports { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<User> Users { get; set; }

    //Defines relationships
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        throw new NotImplementedException();
    }
}