using dashboard_api.Interfaces;
using dashboard_api.Models;

namespace dashboard_api.Services;

public class InvoiceService(IInvoiceRepository invoiceRepository) : IInvoiceService
{
    public async Task<IEnumerable<Invoice>> GetAllInvoicesAsync()
    {
        return await invoiceRepository.GetAllAsync();
    }

    public async Task<Invoice?> GetInvoiceByIdAsync(Guid id)
    {
        return await invoiceRepository.GetByIdAsync(id);
    }

    public async Task<Invoice> CreateInvoiceAsync(Invoice invoice)
    {
        return await invoiceRepository.CreateAsync(invoice);
    }

    public async Task<bool> UpdateInvoiceAsync(Invoice invoice)
    {
        return await invoiceRepository.UpdateAsync(invoice);
    }

    public async Task<bool> DeleteInvoiceAsync(Guid id)
    {
        return await invoiceRepository.DeleteAsync(id);
    }
}
