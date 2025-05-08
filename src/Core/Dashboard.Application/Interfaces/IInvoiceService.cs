using Dashboard.Domain.Entities;

namespace Dashboard.Application.Interfaces;

public interface IInvoiceService
{
    Task<IEnumerable<Invoice>> GetAllInvoicesAsync();
    Task<Invoice?> GetInvoiceByIdAsync(Guid id);
}