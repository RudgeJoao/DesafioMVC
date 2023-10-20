using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Torneio.Data;
using Torneio.Repositories;
using Torneio.Services;

var builder = WebApplication.CreateBuilder(args);
IWebHostEnvironment env = builder.Environment;
IConfiguration Configuration = new ConfigurationBuilder()
              .SetBasePath(env.ContentRootPath)
              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
              .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false)
              .AddEnvironmentVariables()
              .Build();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DbContext, OracleDbContext>(opt =>
{
    opt.UseOracle(Configuration["Database:ConnectionString"]);
    opt.EnableSensitiveDataLogging();
    opt.LogTo(message => Debug.WriteLine(message));

});

builder.Services.AddScoped<ILutadorRepository, LutadorRepository>();
builder.Services.AddScoped<ILutadorService, LutadorService>();
builder.Services.AddScoped<ITorneioRepository, TorneioRepository>();
builder.Services.AddScoped<ITorneioService, TorneioService>();

var app = builder.Build();

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
    pattern: "{controller=Lutadores}/{action=Index}/{id?}");

app.Run();
