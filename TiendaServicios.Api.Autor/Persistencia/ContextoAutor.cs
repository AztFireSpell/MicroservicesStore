﻿using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Autor.Modelo;

namespace TiendaServicios.Api.Autor.Persistencia
{
    public class ContextoAutor: DbContext
    {
        public ContextoAutor(DbContextOptions<ContextoAutor> options) : base(options)
        {
        }

        //Mapeamos las clases, las clases se vuelven de tipo entidad para poder ser mapeadas
        public DbSet<AutorLibro> AutorLibro { get; set; }
        
        public DbSet<GradoAcademico> GradoAcademico { get; set; }
    }
}
