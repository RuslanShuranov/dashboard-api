using Dashboard.Domain.Entities;

namespace Dashboard.Application.Interfaces;

public interface ICustomersService
{
    Task<IEnumerable<Customer>> GetAllCustomersAsync();
    Task<Customer?> GetCustomerByIdAsync(Guid id);
}