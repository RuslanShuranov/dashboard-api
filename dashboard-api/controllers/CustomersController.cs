using dashboard_api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace dashboard_api.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomersController(ICustomerService customerService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var customers = await customerService.GetAllCustomersAsync();
            return Ok(customers);
        }
        catch (Exception ex)
        {
            return Problem($"Error retrieving customers: {ex.Message}");
        }
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        try
        {
            var customer = await customerService.GetCustomerByIdAsync(id);
            return customer == null
                ? NotFound($"Customer with ID {id} not found.")
                : Ok(customer);
        }
        catch (Exception ex)
        {
            return Problem($"Error retrieving customer: {ex.Message}");
        }
    }
}
