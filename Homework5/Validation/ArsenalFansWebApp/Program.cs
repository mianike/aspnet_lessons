using ArsenalFansWebApp.Startup;

namespace ArsenalFansWebApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            ArsenalFansWebAppModule.ConfigureServices(builder);

            var app = builder.Build();

            bool.TryParse(builder.Configuration["SeedDb"], out var seedDb);
            await DbInitializer.InitializeDb(app.Services, seedDb);

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