using System.ComponentModel.DataAnnotations;

namespace dashboard_api.Models;

public class Customer
{
    public Guid Id { get; set; }
    [StringLength(256)]
    public string Name { get; set; } = string.Empty;
    [StringLength(256)]
    public string Email { get; set; } = string.Empty;
    [StringLength(2048)]
    public string ImageUrl { get; set; } = string.Empty;
}
