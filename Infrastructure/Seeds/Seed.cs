using Infrastructure.Data;
using PersonalFinanceAssistant;
using PersonalFinanceAssistant.Entities;

namespace Infrastructure.Seeds;

public class Seed
{
    private readonly DataContext _dataContext;

    public Seed(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public void SeedData()
    {
        if (!_dataContext.Users.Any())
        {
            // Add Users
            var users = new List<User>
            {
                new User
                {
                    Id = Guid.NewGuid(),
                    UserName = "john_doe",
                    Email = "john.doe@example.com",
                    Accounts = new List<Account>(),
                    Budgets = new List<Budget>()
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    UserName = "jane_smith",
                    Email = "jane.smith@example.com",
                    Accounts = new List<Account>(),
                    Budgets = new List<Budget>()
                }
            };

            _dataContext.Users.AddRange(users);
            _dataContext.SaveChanges(); // Save the users first to generate their IDs

            // Add Accounts (associate them with the existing users)
            var accounts = new List<Account>
            {
                new Account
                {
                    Id = Guid.NewGuid(),
                    Name = "John's Checking",
                    Balance = 1000.00m,
                    Transactions = new List<Transaction>(),
                    // Associate with John
                    UserId = users[0].Id  // Set the UserId for John
                },
                new Account
                {
                    Id = Guid.NewGuid(),
                    Name = "Jane's Savings",
                    Balance = 5000.00m,
                    Transactions = new List<Transaction>(),
                    // Associate with Jane
                    UserId = users[1].Id  // Set the UserId for Jane
                }
            };

            _dataContext.Accounts.AddRange(accounts);

            // Add Budgets (associate them with the existing users)
            var budgets = new List<Budget>
            {
                new Budget
                {
                    Id = Guid.NewGuid(),
                    Category = BudgetCategories.Housing,
                    Limit = 1200.00m,
                    Spent = 800.00m,
                    PeriodStart = DateTime.Now.AddMonths(-1),
                    PeriodEnd = DateTime.Now,
                    UserId = users[0].Id  // Set the UserId for John
                },
                new Budget
                {
                    Id = Guid.NewGuid(),
                    Category = BudgetCategories.Food,
                    Limit = 500.00m,
                    Spent = 300.00m,
                    PeriodStart = DateTime.Now.AddMonths(-1),
                    PeriodEnd = DateTime.Now,
                    UserId = users[1].Id  // Set the UserId for Jane
                }
            };

            _dataContext.Budgets.AddRange(budgets);

            // Add Transactions (associate them with the existing accounts)
            var transactions = new List<Transaction>
            {
                new Transaction
                {
                    Id = Guid.NewGuid(),
                    Date = DateTime.Now.AddDays(-10),
                    Description = "Grocery Shopping",
                    Amount = 100.00m,
                    Type = TransactionType.Expense,
                    AccountId = accounts[0].Id  // Set the AccountId for John's Account
                },
                new Transaction
                {
                    Id = Guid.NewGuid(),
                    Date = DateTime.Now.AddDays(-5),
                    Description = "Salary",
                    Amount = 2000.00m,
                    Type = TransactionType.Income,
                    AccountId = accounts[1].Id  // Set the AccountId for Jane's Account
                }
            };

            _dataContext.Transactions.AddRange(transactions);

            // Save changes to the database
            _dataContext.SaveChanges();
        }
    }
}