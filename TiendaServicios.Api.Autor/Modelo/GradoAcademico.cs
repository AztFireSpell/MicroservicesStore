namespace TiendaServicios.Api.Autor.Modelo
{
    public class GradoAcademico
    {
        public int GradoAcademicoId { get; set; }

        public string Nombre { get; set; }

        public string CentroAcademico { get; set; }

        public DateTime? FechaGrado { get; set; }

        //Creamos la relacion 1 a N de GradoAcademico a AutorLibro
        public int AutorLibroId { get; set; }

        public AutorLibro AutorLibro { get; set; }

        //Valor universal para dar seguimiento a un record desde otro microservice
        //Guid -> Global Unique Identifier
        public string GradoAcademicoGuid { get; set; }
        
    }
}
