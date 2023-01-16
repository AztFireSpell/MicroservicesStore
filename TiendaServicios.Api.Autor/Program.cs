using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Autor.Persistencia;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

var builder = WebApplication.CreateBuilder(args);

var Configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", false, true)
    .Build();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ContextoAutor>(options =>
{
options.UseNpgsql(Configuration.GetConnectionString("ConexionDatabase"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
