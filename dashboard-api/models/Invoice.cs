using System.ComponentModel.DataAnnotations;

namespace dashboard_api.Models;

public class Invoice
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public int Amount { get; set; }
    [StringLength(256)]
    public string Status { get; set; } = string.Empty;
    public DateTime Date { get; set; }
}
