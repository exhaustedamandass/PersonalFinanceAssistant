using Application.Mappers;
using Infrastructure.Data;
using Infrastructure.Seeds;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure DbContext with a persistent connection to an in-memory SQLite database
builder.Services.AddDbContext<DataContext>(options => 
    options.UseSqlite("Data Source=InMemorySample;Mode=Memory;Cache=Shared")); // Persistent in-memory database

builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

// Ensure the database is created and seed data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<DataContext>();

    // Ensure database is created
    context.Database.OpenConnection(); // Keep the in-memory DB open
    context.Database.EnsureCreated();  // Create the database structure

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

app.Run();

//TODO : rewrite this
