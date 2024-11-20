using ArsenalFansCore;
using ArsenalFansDAL;
using ArsenalFansWepApp.Startup;

namespace ArsenalFansWepApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            ArsenalFansDALModule.RegisterModule(builder.Services, builder.Configuration);
            ArsenalFansCoreModule.RegisterModule(builder.Services);

            var app = builder.Build();

            DbInitializer.InitializeDb(app.Services);

            if (!app.Environment.IsDevelopment())
            {

                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}