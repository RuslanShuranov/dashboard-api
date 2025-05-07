using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")).UseSnakeCaseNamingConvention());

builder.Services.AddEndpointsApiExplorer();

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

app.MapGet("/invoices/{id:guid}", async (Guid id, ApplicationDbContext db) =>
{
    try
    {
        var invoice = await db.Invoices.FindAsync(id);
        return invoice == null
            ? Results.NotFound($"Invoice with ID {id} not found.")
            : Results.Ok(invoice);
    }
    catch (Exception e)
    {
        return Results.Problem($"Error retrieving invoice: {e.Message}");
    }
}).WithName("GetInvoiceById");

app.MapPost("/invoices", async (ApplicationDbContext db, Invoice invoice) =>
{
    try
    {
        db.Invoices.Add(invoice);
        await db.SaveChangesAsync();
        return Results.Created($"/invoices/{invoice.Id}", invoice);
    }
    catch (Exception e)
    {
        return Results.Problem($"Error creating invoice: {e.Message}");
    }
}).WithName("CreateInvoice");

app.MapPut("/invoices", async (ApplicationDbContext db, Invoice invoice) =>
{
    try
    {
        db.Invoices.Update(invoice);
        await db.SaveChangesAsync();
        return Results.StatusCode(200);
    }
    catch (Exception e)
    {
        return Results.Problem($"Error updating invoice: {e.Message}");
    }
}).WithName("UpdateInvoice");

app.MapDelete("/invoices", async (ApplicationDbContext db, Guid id) =>
{
    try
    {
        var invoice = await db.Invoices.FindAsync(id);
        if (invoice == null) return Results.NotFound();

        db.Invoices.Remove(invoice);
        await db.SaveChangesAsync();
        return Results.StatusCode(200);
    }
    catch (Exception e)
    {
        return Results.Problem($"Error deleting invoice: {e.Message}");
    }
}).WithName("DeleteInvoice");

app.MapGet("/customers", async (ApplicationDbContext db) =>
{
    try
    {
        var customers = await db.Customers.ToListAsync();
        return Results.Ok(customers);
    }
    catch (Exception e)
    {
        return Results.Problem($"Error retrieving customers: {e.Message}");
    }
}).WithName("GetCustomers");

app.Run();

internal class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Invoice> Invoices { get; set; } = null!;
    public DbSet<Customer> Customers { get; set; } = null!;
}

internal class Invoice
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public int Amount { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTime Date { get; set; }
}

internal class Customer
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
}