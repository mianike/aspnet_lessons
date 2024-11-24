using ArsenalFansCore;
using ArsenalFansDAL;
using ArsenalFansWebApp.Mapping;
using ArsenalFansWebApp.Models;
using ArsenalFansWebApp.Validation;
using FluentValidation;

namespace ArsenalFansWebApp.Startup
{
    public static class ArsenalFansWebAppModule
    {
        public static void ConfigureServices(WebApplicationBuilder builder)
        {
            builder.Services.AddControllersWithViews();
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddTransient<IValidator<FeedbackViewModel>, FeedbackViewModelValidator>();

            ArsenalFansDALModule.RegisterModule(builder.Services, builder.Configuration);
            ArsenalFansCoreModule.RegisterModule(builder.Services);


        }
    }
}
