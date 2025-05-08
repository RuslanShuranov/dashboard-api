using Microsoft.EntityFrameworkCore;

namespace Dashboard.Domain.Entities;

public class Invoice
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }

    [Precision(18, 2)] public decimal Amount { get; set; } = decimal.Zero;

    public string Status { get; set; } = string.Empty;
    public string Date { get; set; } = string.Empty;

    public Customer? Customer { get; set; }
}