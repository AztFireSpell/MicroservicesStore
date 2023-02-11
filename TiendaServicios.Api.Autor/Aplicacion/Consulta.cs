using AutoMapper;
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
        public class ListaAutor : IRequest<List<AutorDto>>
        {
            public string AutorLibroGuid { get; set; }
        }

        public class Manejador : IRequestHandler<ListaAutor, List<AutorDto>>
        {
            //Agregamos la logica para crear el query de consulta de autores

           
            private readonly ContextoAutor _contexto;
            //Agregamos la instancia de persistencia - ContextoAutor

            //Instanceamos el mapper
            private readonly IMapper _mapper;
            public Manejador(ContextoAutor contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }
            public async Task<List<AutorDto>> Handle(ListaAutor request, CancellationToken cancellationToken)
            {
                var autores = await _contexto.AutorLibro.ToListAsync();

                var autoresDto = _mapper.Map<List<AutorLibro>, List<AutorDto>>(autores);
                
                return autoresDto;
            }
        }
    }
}
