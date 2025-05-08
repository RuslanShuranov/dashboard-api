using Dashboard.Domain.Entities;
using Dashboard.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Persistence;

public class CustomersDbContext(DbContextOptions<CustomersDbContext> options) : DbContext(options)
{
    public DbSet<Customer> Customers { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
    }
}