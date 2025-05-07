using dashboard_api.Data;
using dashboard_api.Interfaces;
using dashboard_api.Models;
using Microsoft.EntityFrameworkCore;

namespace dashboard_api.Repositories;

public class CustomerRepository(ApplicationDbContext dbContext) : ICustomerRepository
{
    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        return await dbContext.Customers.ToListAsync();
    }

    public async Task<Customer?> GetByIdAsync(Guid id)
    {
        return await dbContext.Customers.FindAsync(id);
    }
}
