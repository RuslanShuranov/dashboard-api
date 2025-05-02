using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")).UseSnakeCaseNamingConvention());

var app = builder.Build();

if (app.Environment.IsDevelopment()) app.MapOpenApi();

app.UseHttpsRedirection();

app.MapGet("/dbconnection", async (ApplicationDbContext db) =>
{
    try
    {
        await db.Database.CanConnectAsync();
        return Results.Ok("Database connection successful!");
    }
    catch (Exception ex)
    {
        return Results.Problem($"Database connection failed: {ex.Message}");
    }
}).WithName("CheckDatabaseConnection");

app.MapGet("/invoices", async (ApplicationDbContext db) =>
{
    try
    {
        var invoices = await db.Invoices.ToListAsync();
        return Results.Ok(invoices);
    }
    catch (Exception ex)
    {
        return Results.Problem($"Error retrieving invoices: {ex.Message}");
    }
}).WithName("GetInvoices");

app.Run();

internal class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Invoice> Invoices { get; set; } = null!;
}

internal class Invoice
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public int Amount { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTime Date { get; set; }
}
