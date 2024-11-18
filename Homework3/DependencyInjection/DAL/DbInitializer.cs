using ArsenalFans.DAL.Data;

namespace ArsenalFans.DAL
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
