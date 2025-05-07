using dashboard_api.Interfaces;
using dashboard_api.Models;

namespace dashboard_api.Services;

public class CustomerService(ICustomerRepository customerRepository) : ICustomerService
{
    public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
    {
        return await customerRepository.GetAllAsync();
    }
    
    public async Task<Customer?> GetCustomerByIdAsync(Guid id)
    {
        return await customerRepository.GetByIdAsync(id);
    }
}
