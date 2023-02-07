using MediatR;
using TiendaServicios.Api.Autor.Modelo;
using TiendaServicios.Api.Autor.Persistencia;

namespace TiendaServicios.Api.Autor.Aplicacion
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }

            public DateTime? FechaNacimiento { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            public readonly ContextoAutor _contexto;

            //Inyectamos, instanciamos, creamos el objeto a traves de un constructor o metodo
            
            public Manejador(ContextoAutor contexto)
            {
                _contexto = contexto;
            }
            
            //Cuando se ejecuta el contructor _contexto deja de ser una variable para ser un objeto

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                //Estamos en una inyeccion de datos, tenemos que devolver un 1(exito) o 0(error)

                //Creamos una instancia y enviamos los valores que obtiene el controller
                var AutorLibro = new AutorLibro
                {
                    Nombre = request.Nombre,
                    Apellido = request.Apellido,
                    FechaNacimiento = request.FechaNacimiento
                };

                _contexto.AutorLibro.Add(AutorLibro);

                //Confirmamos el registro en la DB, primero lo inserta y regresa un valor
                var Valor = await _contexto.SaveChangesAsync();

                if(Valor > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo insertar el autor del libro");
            }
        }
    }
}
