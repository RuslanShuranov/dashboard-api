using dashboard_api.Interfaces;
using dashboard_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace dashboard_api.Controllers;

[ApiController]
[Route("[controller]")]
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
                ? NotFound($"Invoice with ID {id} not found.")
                : Ok(invoice);
        }
        catch (Exception ex)
        {
            return Problem($"Error retrieving invoice: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Invoice invoice)
    {
        try
        {
            var createdInvoice = await invoiceService.CreateInvoiceAsync(invoice);
            return CreatedAtAction(nameof(GetById), new { id = createdInvoice.Id }, createdInvoice);
        }
        catch (Exception ex)
        {
            return Problem($"Error creating invoice: {ex.Message}");
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Invoice invoice)
    {
        try
        {
            var success = await invoiceService.UpdateInvoiceAsync(invoice);
            return success ? Ok() : NotFound();
        }
        catch (Exception ex)
        {
            return Problem($"Error updating invoice: {ex.Message}");
        }
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            var success = await invoiceService.DeleteInvoiceAsync(id);
            return success ? Ok() : NotFound();
        }
        catch (Exception ex)
        {
            return Problem($"Error deleting invoice: {ex.Message}");
        }
    }
}
