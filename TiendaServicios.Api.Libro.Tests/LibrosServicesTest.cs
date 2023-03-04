using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaServicios.Api.Libro.Aplicacion;
using TiendaServicios.Api.Libro.Persistencia;
using GenFu;
using Xunit;
using TiendaServicios.Api.Libro.Modelo;
using Microsoft.EntityFrameworkCore;

namespace TiendaServicios.Api.Libro.Tests
{
    public class LibrosServicesTest
    {

        private IEnumerable<LibreriaMaterial> ObtenerDataPrueba()
        {
            //configuramos la clase que le dara formato Entidad-libreriaMaterial Api Libro
            A.Configure<LibreriaMaterial>()
                .Fill(x => x.Titulo).AsArticleTitle()
                .Fill(x => x.LibreriaMaterialId, () => { return Guid.NewGuid(); });

            var lista = A.ListOf<LibreriaMaterial>(30);
            lista[0].LibreriaMaterialId = Guid.Empty;

            return lista;
        }

        private Mock<ContextoLibreria> CrearContexto()
        {
            var dataPrueba = ObtenerDataPrueba().AsQueryable();
            //Lo hacemos una Entidad de EntityFramework
            var dbSet = new Mock<DbSet<LibreriaMaterial>>();
            dbSet.As<IQueryable<LibreriaMaterial>>().Setup(x => x.Provider).Returns(dataPrueba.Provider);
            dbSet.As<IQueryable<LibreriaMaterial>>().Setup(x => x.Expression).Returns(dataPrueba.Expression);
            dbSet.As<IQueryable<LibreriaMaterial>>().Setup(x => x.ElementType).Returns(dataPrueba.ElementType);
            dbSet.As<IQueryable<LibreriaMaterial>>().Setup(x => x.GetEnumerator()).Returns(dataPrueba.GetEnumerator());
            //Hay que hacer que la clase entidad sea asyncrona (de momento es sincrona)

            dbSet.As<IAsyncEnumerable<LibreriaMaterial>>().Setup(x => x.GetAsyncEnumerator(new System.Threading.CancellationToken()))
                .Returns(new AsyncEnumerator<LibreriaMaterial>(dataPrueba.GetEnumerator()));

            dbSet.As<IQueryable<LibreriaMaterial>>().Setup(x => x.Provider).Returns(new AsyncQueryProvider<LibreriaMaterial>(dataPrueba.Provider));

            var contexto = new Mock<ContextoLibreria>();
            contexto.Setup(x => x.LibreriaMaterial).Returns(dbSet.Object);
            return contexto;
            
        }
        [Fact]
        public async void GetLibroPorId()
        {
            var mockContexto = CrearContexto();

            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingTest());
            });

            var mapper = mapConfig.CreateMapper();

            var request = new ConsultaFiltro.LibroUnico();

            request.LibroId = Guid.Empty;

            var manejador = new ConsultaFiltro.Manejador(mockContexto.Object, mapper);

            var libro  = await manejador.Handle(request, new System.Threading.CancellationToken());

            Assert.NotNull(libro);
            Assert.True(libro.LibreriaMaterialId == Guid.Empty);
        }

        [Fact]
        public async void GetLibros()
        {
            System.Diagnostics.Debugger.Launch();
            //Que metodo dentro de la microservice se encarga de obtener los libros de la DB?
            //1.- Emular a la instancia de EntityFramework Core  (ContextoLibreria)

            //mock es una instancia de un objeto que se comporta como el objeto original
            //pero es controlado solo dentro de TEST
            var mockContexto = CrearContexto();

            //2.- Emular el objeto IMapper
            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingTest());
            });


            var mapper = mapConfig.CreateMapper();
            //3.- Instanciar la clase manejador y pasar como parametros los Mocks

            Consulta.Manejador manejador = new Consulta.Manejador(mockContexto.Object, mapper);

            Consulta.Ejecuta request = new Consulta.Ejecuta();

            var lista = await manejador.Handle(request, new System.Threading.CancellationToken());

            Assert.True(lista.Any());

        }

        [Fact]
        public async void GuardarLibro()
        {
            var options = new DbContextOptionsBuilder<ContextoLibreria>()
                .UseInMemoryDatabase(databaseName: "BaseDatosLibro")
                .Options;
            var contexto = new ContextoLibreria(options);

            var request = new Nuevo.Ejecuta();
            request.Titulo = "Libro Microservice Test";
            request.AutorLibro = Guid.Empty;
            request.FechaPublicacion = DateTime.Now;

            var manejador = new Nuevo.Manejador(contexto);

            var libro = await manejador.Handle(request, new System.Threading.CancellationToken());

            Assert.True(libro != null);
                
        }
    }
}
