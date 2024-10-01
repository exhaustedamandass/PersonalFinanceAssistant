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
        modelBuilder.Entity<User>()
            .HasMany(u => u.Accounts)
            .WithOne()
            .HasForeignKey(a => a.Id)
            .OnDelete(DeleteBehavior.Cascade);

        // Define the one-to-many relationship between User and Budgets
        modelBuilder.Entity<User>()
            .HasMany(u => u.Budgets)
            .WithOne()
            .HasForeignKey(b => b.Id)
            .OnDelete(DeleteBehavior.Cascade);

        // Define the one-to-many relationship between Account and Transactions
        modelBuilder.Entity<Account>()
            .HasOne(a => a.User)
            .WithMany(u => u.Accounts)
            .HasForeignKey(a => a.UserId)
            .OnDelete(DeleteBehavior.Cascade); 

        // Define the many-to-one relationship between Transaction and Account
        modelBuilder.Entity<Transaction>()
            .HasOne<Account>()
            .WithMany(a => a.Transactions)
            .HasForeignKey(t => t.AccountId);

        // Define the one-to-many relationship between Report and Transactions
        modelBuilder.Entity<Report>()
            .HasMany(r => r.Transactions)
            .WithOne()
            .HasForeignKey(t => t.Id)  // Adjust according to your reporting logic
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<Budget>()
            .HasOne(b => b.User)
            .WithMany(u => u.Budgets)
            .HasForeignKey(b => b.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Customize properties if needed
        modelBuilder.Entity<Transaction>()
            .Property(t => t.Amount)
            .HasColumnType("decimal(18,2)");
    }
}