using dashboard_api.Data;
using dashboard_api.Interfaces;
using dashboard_api.Models;
using Microsoft.EntityFrameworkCore;

namespace dashboard_api.Repositories;

public class InvoiceRepository(ApplicationDbContext dbContext) : IInvoiceRepository
{
    public async Task<IEnumerable<Invoice>> GetAllAsync()
    {
        return await dbContext.Invoices.ToListAsync();
    }

    public async Task<Invoice?> GetByIdAsync(Guid id)
    {
        return await dbContext.Invoices.FindAsync(id);
    }

    public async Task<Invoice> CreateAsync(Invoice invoice)
    {
        dbContext.Invoices.Add(invoice);
        await dbContext.SaveChangesAsync();
        return invoice;
    }

    public async Task<bool> UpdateAsync(Invoice invoice)
    {
        dbContext.Invoices.Update(invoice);
        return await dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var invoice = await dbContext.Invoices.FindAsync(id);
        if (invoice == null) return false;

        dbContext.Invoices.Remove(invoice);
        return await dbContext.SaveChangesAsync() > 0;
    }
}
