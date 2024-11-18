using ArsenalFans.Services;
using ArsenalFans.Services.Contracts;
using ArsenalFans.DAL.Data;
using Microsoft.EntityFrameworkCore;
using ArsenalFans.DAL;
using ArsenalFans.DAL.Repositories.Contracts;
using ArsenalFans.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Data source configuration in appsettings.Development.json
var playerServiceType = builder.Configuration["PlayerService"];
var isPostgres = string.Equals(playerServiceType, "Postgres", StringComparison.CurrentCultureIgnoreCase);

if (isPostgres)
{
    builder.Services.AddDbContext<ArsenalDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

    builder.Services.AddTransient<IPlayerRepository, PostgresPlayerRepository>();
    builder.Services.AddTransient<IPlayerService, PostgresPlayerService>();
}
else
{
    builder.Services.AddTransient<IPlayerRepository, JsonPlayerRepository>();
    builder.Services.AddTransient<IPlayerService, JsonPlayerService>();
}

var app = builder.Build();

if (isPostgres)
{
    DbInitializer.InitializeDb(app.Services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{

    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
