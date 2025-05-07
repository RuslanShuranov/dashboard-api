using dashboard_api.Data;

namespace dashboard_api.Services;

public class DatabaseService(ApplicationDbContext dbContext)
{
    public async Task<bool> CanConnectAsync()
    {
        return await dbContext.Database.CanConnectAsync();
    }
}
