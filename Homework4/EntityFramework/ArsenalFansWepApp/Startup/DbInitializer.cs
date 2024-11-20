using ArsenalFansDAL.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ArsenalFansWepApp.Startup
{
    public static class DbInitializer
    {
        public static void InitializeDb(IServiceProvider services)
        {
            using var scope = services.CreateScope();

            var dbcontext = scope.ServiceProvider.GetRequiredService<ArsenalDbContext>();

            dbcontext.Database.Migrate();
        }
    }
}
