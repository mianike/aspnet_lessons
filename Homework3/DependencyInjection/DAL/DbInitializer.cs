using ArsenalFans.DAL.Data;

namespace SynopticumWebAPI
{
    public static class DbInitializer
    {
        public static void InitializeDb(IServiceProvider services)
        {
            using var scope = services.CreateScope();

            var dbcontext = scope.ServiceProvider.GetRequiredService<ArsenalDbContext>();

            dbcontext.Database.EnsureCreated();
        }
    }
}
