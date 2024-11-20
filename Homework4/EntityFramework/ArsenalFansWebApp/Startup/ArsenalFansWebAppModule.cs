using ArsenalFansCore;
using ArsenalFansDAL;
using ArsenalFansWebApp.Mapping;

namespace ArsenalFansWebApp.Startup
{
    public static class ArsenalFansWebAppModule
    {
        public static void ConfigureServices(WebApplicationBuilder builder)
        {
            builder.Services.AddControllersWithViews();
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            ArsenalFansDALModule.RegisterModule(builder.Services, builder.Configuration);
            ArsenalFansCoreModule.RegisterModule(builder.Services);


        }
    }
}
