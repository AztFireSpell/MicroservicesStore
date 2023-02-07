using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Autor.Modelo;
using TiendaServicios.Api.Autor.Persistencia;

namespace TiendaServicios.Api.Autor.Aplicacion
{
    public class Consulta
    {
        /// <summary>
        /// IRequest <Mapea los valores que se obtienen desde el controller>
        /// </summary>
        public class ListaAutor : IRequest<List<AutorLibro>>
        {
            public string AutorLibroGuid { get; set; }
        }

        public class Manejador : IRequestHandler<ListaAutor, List<AutorLibro>>
        {
            //Agregamos la logica para crear el query de consulta de autores

           
            private readonly ContextoAutor _contexto;
            //Agregamos la instancia de persistencia - ContextoAutor
            public Manejador(ContextoAutor contexto)
            {
                _contexto = contexto;
            }
            public async Task<List<AutorLibro>> Handle(ListaAutor request, CancellationToken cancellationToken)
            {
                var autores = await _contexto.AutorLibro.ToListAsync();
                return autores;
            }
        }
    }
}
