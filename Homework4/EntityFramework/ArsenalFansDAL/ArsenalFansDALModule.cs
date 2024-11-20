using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ArsenalFansDAL.Services;
using ArsenalFansDAL.Contracts.Interfaces;
using ArsenalFansDAL.Contexts;

namespace ArsenalFansDAL
{
    public static class ArsenalFansDALModule
    {
        public static void RegisterModule(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ArsenalDbContext>(
                options => options
                    .UseNpgsql(connectionString));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
