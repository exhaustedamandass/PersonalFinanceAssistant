using Application.Mappers;
using Infrastructure.Data;
using Infrastructure.Seeds;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceAssistant.Services;

var builder = WebApplication.CreateBuilder(args);

var connection = new SqliteConnection("Data Source=InMemorySample;Mode=Memory;Cache=Shared");
connection.Open(); // Add services to the container.

// Configure Kestrel with increased header size limits
builder.WebHost.ConfigureKestrel(options =>
{
    options.Limits.MaxRequestHeadersTotalSize = 65536;  // Increase to 64 KB (default is 32 KB)
    // You can also configure other limits like MaxRequestBodySize if needed.
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure DbContext with a persistent connection to an in-memory SQLite database
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlite(connection));// Persistent in-memory database

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddSpaStaticFiles(configuration =>
{
    configuration.RootPath = "clientapp/build";  // Path to React production build
});

// Add controllers support
builder.Services.AddControllers();

builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBudgetService, BudgetService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IReportService, ReportService>();

var app = builder.Build();

// Ensure the database is created and seed data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<DataContext>();

    // Ensure database is created
    context.Database.OpenConnection(); // Keep the in-memory DB open

    var result = context.Database.EnsureCreated();  // Create the database structure
    if (result)
    {
        Console.WriteLine("Database was created.");
    }
    else
    {
        Console.WriteLine("Database already exists or failed to create.");
    }

    // Seed the data
    var seed = new Seed(context);
    seed.SeedData();

    var accounts = context.Accounts.ToList(); // Query the Accounts table
    if (accounts.Any())
    {
        Console.WriteLine($"Seeding successful. Number of accounts: {accounts.Count}");
        foreach (var account in accounts)
        {
            Console.WriteLine($"Account Name: {account.Name}, Balance: {account.Balance}");
        }
    }
    else
    {
        Console.WriteLine("Seeding failed or no accounts in the database.");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseSpa(spa =>
    {
        spa.Options.SourcePath = "clientapp";  // Development path to React app
        spa.UseReactDevelopmentServer(npmScript: "start");
    });
}

app.UseHttpsRedirection();

// Use top-level route registration for controllers
app.MapControllers();

app.Run();
