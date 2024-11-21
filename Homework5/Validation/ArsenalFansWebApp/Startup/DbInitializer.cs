using ArsenalFansDAL.Contexts;
using ArsenalFansDAL.DbSeed;
using Microsoft.EntityFrameworkCore;

namespace ArsenalFansWebApp.Startup
{
    public static class DbInitializer
    {
        public static async Task InitializeDb(IServiceProvider services, bool seedDb)
        {
            using var scope = services.CreateScope();

            var dbContext = scope.ServiceProvider.GetRequiredService<ArsenalDbContext>();

            dbContext.Database.Migrate();

            if (seedDb)
            {
                await ArsenalDbSeed.PlayerSeed(dbContext);
            }
        }
    }
}