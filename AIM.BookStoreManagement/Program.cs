using AIM.BookStoreManagement.DB.Context;
using AIM.BookStoreManagement.GraphQL.Mutations;
using AIM.BookStoreManagement.GraphQL.Queries;
using AIM.BookStoreManagement.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();



// Configure EF Core to use PostgreSQL with the connection string
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(Environment.GetEnvironmentVariable("ConnectionString")));

// Fix DateTime/Timestamp Compatibility (Recommended for Npgsql 6.0+)
// Npgsql 6.0+ changed its default timestamp mapping. You might need this for older configurations.
System.AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add services DI
builder.Services.AddServices();
builder.Services.AddJwtAuthentication();
builder.Services.AddCorsPolicy();


// 4. Register GraphQL Server, Query, and Mutation Roots
builder.Services.AddGraphQl();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(); 
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// ==========================================================
// 5. AUTOMATIC MIGRATION SETUP (NEW CODE)
// ==========================================================
// This code block ensures all pending migrations are applied on startup.
// IMPORTANT: This should be called before app.Run()
try
{
    // Create a new scope to resolve the DbContext instance
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    // Apply any pending migrations to the database
    dbContext.Database.Migrate();

    // Optional: Log success
    // Console.WriteLine("Database migrations successfully applied.");
}
catch (Exception ex)
{
    // Log the error if migration fails (e.g., connection issue, bad connection string)
    // Console.WriteLine($"Failed to apply migrations: {ex.Message}");
    // Note: In production, consider robust error handling or manual migration processes.
}
// ==========================================================

app.MapGraphQL();       // GraphQL endpoints (if any)

app.Run();
