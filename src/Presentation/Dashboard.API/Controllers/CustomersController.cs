using Dashboard.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController(ICustomersService customersService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var customers = await customersService.GetAllCustomersAsync();
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
            var customer = await customersService.GetCustomerByIdAsync(id);
            return customer == null
                ? NotFound()
                : Ok(customer);
        }
        catch (Exception ex)
        {
            return Problem($"Error retrieving customer: {ex.Message}");
        }
    }
}