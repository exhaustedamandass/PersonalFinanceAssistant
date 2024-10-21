using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
        // User and Accounts relationship
        modelBuilder.Entity<User>()
            .HasMany(u => u.Accounts)
            .WithOne(a => a.User)
            .HasForeignKey(a => a.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // User and Budgets relationship
        modelBuilder.Entity<User>()
            .HasMany(u => u.Budgets)
            .WithOne(b => b.User)
            .HasForeignKey(b => b.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Account and Transactions relationship
        modelBuilder.Entity<Account>()
            .HasMany(a => a.Transactions)
            .WithOne(t => t.Account)
            .HasForeignKey(t => t.AccountId)
            .OnDelete(DeleteBehavior.Cascade);

        // Report has many Transactions (no reverse relationship)
        modelBuilder.Entity<Report>()
            .HasMany(r => r.Transactions)
            .WithMany() // No back reference to Report in Transaction
            .UsingEntity(j => j.ToTable("ReportTransactions")); // Join table

        // Budget and User relationship
        modelBuilder.Entity<Budget>()
            .HasOne(b => b.User)
            .WithMany(u => u.Budgets)
            .HasForeignKey(b => b.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Set the precision for Transaction Amount
        modelBuilder.Entity<Transaction>()
            .Property(t => t.Amount)
            .HasColumnType("decimal(18,2)");
    }
}