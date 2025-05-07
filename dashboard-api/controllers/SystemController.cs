using dashboard_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace dashboard_api.Controllers;

[ApiController]
[Route("[controller]")]
public class SystemController(DatabaseService databaseService) : ControllerBase
{
    [HttpGet("dbconnection")]
    public async Task<IActionResult> CheckDatabaseConnection()
    {
        try
        {
            var connected = await databaseService.CanConnectAsync();
            return Ok("Database connection successful!");
        }
        catch (Exception ex)
        {
            return Problem($"Database connection failed: {ex.Message}");
        }
    }
}
