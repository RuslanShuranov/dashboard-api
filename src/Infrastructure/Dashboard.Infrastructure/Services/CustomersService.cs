using Dashboard.Application.Interfaces;
using Dashboard.Domain.Entities;
using Dashboard.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Infrastructure.Services;

public class CustomersService(CustomersDbContext dbContext) : ICustomersService
{
    public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
    {
        return await dbContext.Customers.AsNoTracking().ToListAsync();
    }

    public async Task<Customer?> GetCustomerByIdAsync(Guid id)
    {
        return await dbContext.Customers
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);
    }
}