using dashboard_api.Models;
using Microsoft.EntityFrameworkCore;

namespace dashboard_api.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Invoice> Invoices { get; set; } = null!;
    public DbSet<Customer> Customers { get; set; } = null!;
}
