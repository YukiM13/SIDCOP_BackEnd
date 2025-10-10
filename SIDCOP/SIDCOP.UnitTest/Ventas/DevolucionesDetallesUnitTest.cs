using FluentAssertions;
using Moq;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.DataAccess.Repositories.Ventas;
using SIDCOP_Backend.Entities.Entities;
using SIDCOP_Backend.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIDCOP.UnitTest.Ventas
{
    public class DevolucionesDetallesUnitTest
    {
        //repositorio que se usara haciendolo con mock
        private readonly Mock<DevolucionesDetallesRepository> _repository;
        //service que usa ese repositorio
        private readonly VentaServices _service;

        //prepara el entorno de pruebas 
        public DevolucionesDetallesUnitTest()
        {
            //crear un mock del repositorio para no usar la bdd
            _repository = new Mock<DevolucionesDetallesRepository>();

            //service con el repositorio mockeado en la posición correcta
            _service = new VentaServices(null, null, null, null, null, null, null, null, null, null, null, null, 
                                        _repository.Object, null);
        }

        //marca el metodo que le sigue como una prueba unitaria (xunit)
        [Fact]
        //unit test del buscar devoluciones detalle
        public void DevolucionesDetalleBuscar()
        {
            //declaracion de una lista de devoluciones detalle que se usará
            var modelo = new List<tbDevolucionesDetalle>()
            {
                new tbDevolucionesDetalle { DevD_Id = 1, Devo_Id = 1, Prod_Id = 10, 
                                          DevD_Cantidad = 2, Usua_Creacion = 1, DevD_Estado = true },
                new tbDevolucionesDetalle { DevD_Id = 2, Devo_Id = 1, Prod_Id = 20, 
                                          DevD_Cantidad = 1, Usua_Creacion = 1, DevD_Estado = true },
                new tbDevolucionesDetalle { DevD_Id = 3, Devo_Id = 1, Prod_Id = 30, 
                                          DevD_Cantidad = 3, Usua_Creacion = 1, DevD_Estado = true }
            }.AsEnumerable();

            //esto ejecuta la funcion del repositorio
            _repository.Setup(d => d.FindDetalle(1))
                .Returns(modelo);

            //ejecutando el service y guardando el result
            var result = _service.BuscarDevolucionDetalle(1);

            //cantidad de objetos esperada
            result.Should().HaveCount(3);

            //un registro que contenga algo en especifico
            result.Should().ContainSingle(x => x.DevD_Id == 2);
        }
    }
}
