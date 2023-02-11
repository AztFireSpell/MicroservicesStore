using TiendaServicios.Api.Autor.Modelo;

namespace TiendaServicios.Api.Autor.Aplicacion
{
    public class AutorDto
    {
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public DateTime? FechaNacimiento { get; set; }

        //Valor universal para dar seguimiento a un record desde otro microservice
        public string AutorLibroGuid { get; set; }
    }
}
