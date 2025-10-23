using FluentAssertions;
using Microsoft.SqlServer.Management.Smo.Wmi;
using Moq;
using SIDCOP_Backend.BusinessLogic;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.DataAccess;
using SIDCOP_Backend.DataAccess.Repositories.General;
using SIDCOP_Backend.DataAccess.Repositories.Logistica;
using SIDCOP_Backend.DataAccess.Repositories.Ventas;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP.UnitTest.General
{
    public class ImagenVisitaUnitTest
    {
        private readonly Mock<ImagenVisitaRepository> _repository;
        private readonly GeneralServices _service;

        public ImagenVisitaUnitTest()
        {
            //Crear un mock del repositorio para no usar la bdd, aqui podemos controlar que devuelve cada funcion del repositorio.
            _repository = new Mock<ImagenVisitaRepository>();

            //Service con lo que se explica abajo usando el repo declarado arriba.
            //Los null se ponen segun la cantidad de repositorios que hayan antes y despues del que estamos utilizando.
            _service = new GeneralServices(null, null, null, null, null, null, null, null, null,
                                            null, null, null, null, null, null, null, null, null, null, null,
                                            _repository.Object, null, null);
        }


        [Fact]
        //Prueba Unitaria para insertar.
        public void ImagenVisitaInsertar()
        {
            //Declaramos un elemento a insertar (que lleve algo aunque sea).
            var item = new tbImagenesVisita
            {
                ImVi_Imagen = "ImagenVisita.jpg",
                ClVi_Id = 15,
                //Agregar los demas campos si es necesario.
            };

            //El insertar del repositorio con las cosas esperadas que devuelva.
            _repository.Setup(pl => pl.Insert(item))
              .Returns(new RequestStatus { code_Status = 1, message_Status = "Imagen de la visita registrada correctamente." });
            //

            //Ejecuta el insertar del service y guarda el result de este mismo.
            var result = _service.InsertImVi(item);

            //Success por como lo tenemos siempre dara true así que luego evaluamos lo del data que se manda desde.
            //El sp en la base de datos.
            result.Success.Should().BeTrue();

            //Cosas del data del sp.
            //Si el code_Status es un entonces si se insertó, en caso que tire error es que no insertó nada.
            ((int)result.Data.code_Status).Should().Be(1);
            //Si el message_Status es el esperado entonces se cumplio que si insertó.
            ((string)result.Data.message_Status).Should().Be("Imagen de la visita registrada correctamente.");
            //Validar que se llamo solo una vez durante la ejecucion.
            _repository.Verify(r => r.Insert(item), Times.Once);
        }

        [Fact]
        public void ListImagenesPorVisita()
        {
            // Arrange
            int visitaId = 5;

            // Crear una lista simulada de imágenes que retornará el repositorio
            var imagenesEsperadas = new List<tbImagenesVisita>
    {
        new tbImagenesVisita
        {
            ImVi_Id = 1,
            ClVi_Id = 5,
            ImVi_Imagen = "imagen1.jpg",
            // Agregar otros campos según tu entidad
        },
        new tbImagenesVisita
        {
            ImVi_Id = 2,
            ClVi_Id = 5,
            ImVi_Imagen = "imagen2.jpg",
        }
    };

            // Setup del repositorio
            _repository.Setup(r => r.ListPorVisita(visitaId))
                .Returns(imagenesEsperadas);

            // Act
            var result = _service.ListPorVisita(visitaId); // O el nombre que tenga en tu service

            // Assert
            // Verificar que el resultado no sea nulo
            result.Should().NotBeNull();

            // Verificar que se encontraron 2 imágenes
            result.Should().HaveCount(2);

            // Verificar que todas las imágenes pertenecen a la visita correcta
            result.Should().OnlyContain(img => img.ClVi_Id == visitaId);

            // Verificar que contiene las imágenes esperadas
            result.First().ImVi_Id.Should().Be(1);
            result.First().ImVi_Imagen.Should().Be("imagen1.jpg");

            // Validar que se llamó solo una vez durante la ejecución
            _repository.Verify(r => r.ListPorVisita(visitaId), Times.Once);
        }

    }
}
