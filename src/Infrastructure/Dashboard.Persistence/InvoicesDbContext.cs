using Dashboard.Domain.Entities;
using Dashboard.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Persistence;

public class InvoicesDbContext(DbContextOptions<InvoicesDbContext> options) : DbContext(options)
{
    public DbSet<Invoice> Invoices { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new InvoiceConfiguration());
    }
}