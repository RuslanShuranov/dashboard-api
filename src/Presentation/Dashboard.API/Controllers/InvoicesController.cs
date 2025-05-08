using Dashboard.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InvoicesController(IInvoiceService invoiceService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var invoices = await invoiceService.GetAllInvoicesAsync();
            return Ok(invoices);
        }
        catch (Exception ex)
        {
            return Problem($"Error retrieving invoices: {ex.Message}");
        }
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        try
        {
            var invoice = await invoiceService.GetInvoiceByIdAsync(id);
            return invoice == null
                ? NotFound()
                : Ok(invoice);
        }
        catch (Exception ex)
        {
            return Problem($"Error retrieving invoice: {ex.Message}");
        }
    }
}