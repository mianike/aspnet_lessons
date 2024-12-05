using CarSpecificationsAPI.Startup;

namespace CarSpecificationsAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            CarSpecificationsAPIModule.ConfigureServices(builder);

            var app = builder.Build();

            app.InitializePipeline();

            app.MapControllers();

            app.Run();
        }
    }
}