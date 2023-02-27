namespace TiendaServicios.Api.CarritoCompra.Aplicacion
{
    public class CarritoDetalleDto
    {
        public Guid? LibroId { get; set; }
        public string Titulolibro { get; set; }
        public string Autorlibro { get; set; }
        public DateTime? FechaPublicacion { get; set; }
    }
}
