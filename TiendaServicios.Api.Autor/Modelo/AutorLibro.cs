using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace TiendaServicios.Api.Autor.Modelo
{
    public class AutorLibro
    {
        public int AutorLibroId { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public DateTime? FechaNacimiento { get; set; }

        //Creamos la relacion 1 a N con GradoAcademico
        public ICollection<GradoAcademico> ListaGradoAcademico { get; set; }

        //Valor universal para dar seguimiento a un record desde otro microservice
        public string AutorLibroGuid { get; set; }
    }
}
