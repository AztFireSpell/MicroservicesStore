using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Autor.Persistencia;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using TiendaServicios.Api.Autor.Aplicacion;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

var Configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", false, true)
    .Build();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ContextoAutor>(options =>
{
    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    options.UseNpgsql(Configuration.GetConnectionString("ConexionDatabase"));
});

//Esta linea solo se agrega una vez, ya que se queda como interface de MediatR
builder.Services.AddMediatR(typeof(Nuevo.Manejador).Assembly);

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
