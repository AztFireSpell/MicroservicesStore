using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using TiendaServicios.Api.Libro.Modelo;

namespace TiendaServicios.Api.Libro.Persistencia
{
    public class ContextoLibreria: DbContext
    {
        public ContextoLibreria(DbContextOptions<ContextoLibreria> options) : base(options) { }
        
        public DbSet<LibreriaMaterial> LibreriaMaterial { get; set; }
        
    }
}
