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
    }
}
