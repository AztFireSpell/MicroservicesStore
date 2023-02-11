using AutoMapper;
using TiendaServicios.Api.Autor.Modelo;

namespace TiendaServicios.Api.Autor.Aplicacion
{
    public class MappingProfile : Profile
    {
        //Agregamos los mapeos de una clase y clase Dto
        public MappingProfile()
        {
            CreateMap<AutorLibro, AutorDto>();
        }
    }
}
