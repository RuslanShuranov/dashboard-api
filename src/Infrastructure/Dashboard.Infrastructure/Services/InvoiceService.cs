using Dashboard.Application.Interfaces;
using Dashboard.Domain.Entities;
using Dashboard.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Infrastructure.Services;

public class InvoiceService(InvoicesDbContext dbContext) : IInvoiceService
{
    public async Task<IEnumerable<Invoice>> GetAllInvoicesAsync()
    {
        return await dbContext.Invoices.AsNoTracking().ToListAsync();
    }

    public async Task<Invoice?> GetInvoiceByIdAsync(Guid id)
    {
        return await dbContext.Invoices
            .AsNoTracking()
            .FirstOrDefaultAsync(i => i.Id == id);
    }
}