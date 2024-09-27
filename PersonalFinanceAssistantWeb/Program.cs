using Application.Mappers;
using Infrastructure.Data;
using Infrastructure.Seeds;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options => 
    options.UseSqlite("Data Source=:memory:"));  // In-memory SQLite DB for testing
builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

// Ensure the database is created and seed data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<DataContext>();

    // Ensure database is created
    context.Database.EnsureCreated();

    // Seed the data
    var seed = new Seed(context);
    seed.SeedData();  // Call the method that seeds the data
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//TODO : rewrite this


var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", async (DataContext context) =>
    {
        // Use DataContext within the endpoint
        var categories = await context.Categories.ToListAsync();
        return categories; // Just an example, modify based on your needs
    })
    .WithName("GetWeatherForecast")
    .WithOpenApi();

app.Run();