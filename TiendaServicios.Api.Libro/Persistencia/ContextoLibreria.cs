using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using TiendaServicios.Api.Libro.Modelo;

namespace TiendaServicios.Api.Libro.Persistencia
{
    public class ContextoLibreria: DbContext
    {
        public ContextoLibreria() { }
        
        public ContextoLibreria(DbContextOptions<ContextoLibreria> options) : base(options) { }
        //Virtual es para que se pueda sobreescribir
        public virtual DbSet<LibreriaMaterial> LibreriaMaterial { get; set; }
        
    }
}
