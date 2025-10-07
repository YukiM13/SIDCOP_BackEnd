using FluentAssertions;
using Moq;
using SIDCOP_Backend.BusinessLogic;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.DataAccess;
using SIDCOP_Backend.DataAccess.Repositories.Ventas;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP.UnitTest.Ventas
{
    public class MetasUnitTest
    {
       
        private readonly Mock<MetaRepository> _repository;

        private readonly VentaServices _service;

 
        public MetasUnitTest()
        {


            _repository = new Mock<MetaRepository>();


            _service = new VentaServices(null, null, null, null, null, null, null, null, null,
                                        null,
                                        null, null, null, _repository.Object
            );
        }


        [Fact]
        public void MetasListarCompleto()
        {

            var modelo = new List<tbMetas>()
            {
               new tbMetas { Meta_Id = 1, Meta_Descripcion = "Meta 1",
                                           Meta_FechaInicio = DateTime.Now, Meta_FechaFin = DateTime.Now.AddMonths(1),
                                           Meta_Tipo = "Tipo A", Meta_Ingresos = 1000, Meta_Unidades = 50,
                                           Prod_Id = 2, Cate_Id = null, Meta_Estado = true,
                                           Usua_Creacion = 1, Meta_FechaCreacion = DateTime.Now,
                                           Usua_Modificacion = null, Meta_FechaModificacion = null,
                                           VendedoresXml =  null,
                                           VendedoresJson = "[{\"Vend_Id\":22,\"Vend_NombreCompleto\":\"Daniel Fernández\",\"MeEm_ProgresoIngresos\":0.00,\"MeEm_ProgresoUnidades\":0.00,\"Usua_Creacion\":1,\"MeEm_FechaCreacion\":\"2025-08-26T21:57:01.583\"},{\"Vend_Id\":18,\"Vend_NombreCompleto\":\"Josué Cerna\",\"MeEm_ProgresoIngresos\":0.00,\"MeEm_ProgresoUnidades\":0.00,\"Usua_Creacion\":1,\"MeEm_FechaCreacion\":\"2025-08-26T21:57:01.583\"}]",
                                           DetallesXml = null,
                                },
                new tbMetas { Meta_Id = 2, Meta_Descripcion = "Meta 2",
                                           Meta_FechaInicio = DateTime.Now, Meta_FechaFin = DateTime.Now.AddMonths(1),
                                           Meta_Tipo = "Tipo B", Meta_Ingresos = 2000, Meta_Unidades = 100,
                                           Prod_Id = 3, Cate_Id = null, Meta_Estado = true,
                                           Usua_Creacion = 1, Meta_FechaCreacion = DateTime.Now,
                                           Usua_Modificacion = null, Meta_FechaModificacion = null,
                                           VendedoresXml =  null,
                                           VendedoresJson = "[{\"Vend_Id\":23,\"Vend_NombreCompleto\":\"Daniel Fernández\",\"MeEm_ProgresoIngresos\":0.00,\"MeEm_ProgresoUnidades\":0.00,\"Usua_Creacion\":1,\"MeEm_FechaCreacion\":\"2025-08-26T21:57:01.583\"},{\"Vend_Id\":18,\"Vend_NombreCompleto\":\"Josué Cerna\",\"MeEm_ProgresoIngresos\":0.00,\"MeEm_ProgresoUnidades\":0.00,\"Usua_Creacion\":1,\"MeEm_FechaCreacion\":\"2025-08-26T21:57:01.583\"}]",
                                           DetallesXml = null,
                                },
                new tbMetas { Meta_Id = 3, Meta_Descripcion = "Meta 3",
                                           Meta_FechaInicio = DateTime.Now, Meta_FechaFin = DateTime.Now.AddMonths(1),
                                           Meta_Tipo = "Tipo A", Meta_Ingresos = 1500, Meta_Unidades = 75,
                                           Prod_Id = 2, Cate_Id = null, Meta_Estado = true,
                                           Usua_Creacion = 1, Meta_FechaCreacion = DateTime.Now,
                                           Usua_Modificacion = null, Meta_FechaModificacion = null,
                                           VendedoresXml =  null,
                                           VendedoresJson = "[{\"Vend_Id\":21,\"Vend_NombreCompleto\":\"Daniel Fernández\",\"MeEm_ProgresoIngresos\":0.00,\"MeEm_ProgresoUnidades\":0.00,\"Usua_Creacion\":1,\"MeEm_FechaCreacion\":\"2025-08-26T21:57:01.583\"},{\"Vend_Id\":18,\"Vend_NombreCompleto\":\"Josué Cerna\",\"MeEm_ProgresoIngresos\":0.00,\"MeEm_ProgresoUnidades\":0.00,\"Usua_Creacion\":1,\"MeEm_FechaCreacion\":\"2025-08-26T21:57:01.583\"}]",
                                           DetallesXml = null,
                                },
            }.AsEnumerable();


            _repository.Setup(pl => pl.ListCompleto())
                .Returns(modelo);

            var result = _service.ListMetasCompleto();

            result.Should().HaveCount(3);

            result.Should().ContainSingle(x => x.Meta_Id == 2);
        }

        [Fact]
        public void MetasListarPorVendedor()
        {

            var modelo = new List<tbMetas>()
            {
                new tbMetas { Meta_Id = 1, Meta_Descripcion = "Meta 1",
                                           Meta_FechaInicio = DateTime.Now, Meta_FechaFin = DateTime.Now.AddMonths(1),
                                           Meta_Tipo = "Tipo A", Meta_Ingresos = 1000, Meta_Unidades = 50,
                                           Prod_Id = 2, Cate_Id = null, Meta_Estado = true,
                                           Usua_Creacion = 1, Meta_FechaCreacion = DateTime.Now,
                                           Usua_Modificacion = null, Meta_FechaModificacion = null,
                                           VendedoresXml =  null,
                                           VendedoresJson = "[{\"Vend_Id\":22,\"Vend_NombreCompleto\":\"Daniel Fernández\",\"MeEm_ProgresoIngresos\":0.00,\"MeEm_ProgresoUnidades\":0.00,\"Usua_Creacion\":1,\"MeEm_FechaCreacion\":\"2025-08-26T21:57:01.583\"},{\"Vend_Id\":18,\"Vend_NombreCompleto\":\"Josué Cerna\",\"MeEm_ProgresoIngresos\":0.00,\"MeEm_ProgresoUnidades\":0.00,\"Usua_Creacion\":1,\"MeEm_FechaCreacion\":\"2025-08-26T21:57:01.583\"}]",
                                           DetallesXml = null,
                                },
                new tbMetas { Meta_Id = 2, Meta_Descripcion = "Meta 2",
                                           Meta_FechaInicio = DateTime.Now, Meta_FechaFin = DateTime.Now.AddMonths(1),
                                           Meta_Tipo = "Tipo B", Meta_Ingresos = 2000, Meta_Unidades = 100,
                                           Prod_Id = 3, Cate_Id = null, Meta_Estado = true,
                                           Usua_Creacion = 1, Meta_FechaCreacion = DateTime.Now,
                                           Usua_Modificacion = null, Meta_FechaModificacion = null,
                                           VendedoresXml =  null,
                                           VendedoresJson = "[{\"Vend_Id\":23,\"Vend_NombreCompleto\":\"Daniel Fernández\",\"MeEm_ProgresoIngresos\":0.00,\"MeEm_ProgresoUnidades\":0.00,\"Usua_Creacion\":1,\"MeEm_FechaCreacion\":\"2025-08-26T21:57:01.583\"},{\"Vend_Id\":18,\"Vend_NombreCompleto\":\"Josué Cerna\",\"MeEm_ProgresoIngresos\":0.00,\"MeEm_ProgresoUnidades\":0.00,\"Usua_Creacion\":1,\"MeEm_FechaCreacion\":\"2025-08-26T21:57:01.583\"}]",
                                           DetallesXml = null,
                                },
                new tbMetas { Meta_Id = 3, Meta_Descripcion = "Meta 3",
                                           Meta_FechaInicio = DateTime.Now, Meta_FechaFin = DateTime.Now.AddMonths(1),
                                           Meta_Tipo = "Tipo A", Meta_Ingresos = 1500, Meta_Unidades = 75,
                                           Prod_Id = 2, Cate_Id = null, Meta_Estado = true,
                                           Usua_Creacion = 1, Meta_FechaCreacion = DateTime.Now,
                                           Usua_Modificacion = null, Meta_FechaModificacion = null,
                                           VendedoresXml =  null,
                                           VendedoresJson = "[{\"Vend_Id\":21,\"Vend_NombreCompleto\":\"Daniel Fernández\",\"MeEm_ProgresoIngresos\":0.00,\"MeEm_ProgresoUnidades\":0.00,\"Usua_Creacion\":1,\"MeEm_FechaCreacion\":\"2025-08-26T21:57:01.583\"},{\"Vend_Id\":18,\"Vend_NombreCompleto\":\"Josué Cerna\",\"MeEm_ProgresoIngresos\":0.00,\"MeEm_ProgresoUnidades\":0.00,\"Usua_Creacion\":1,\"MeEm_FechaCreacion\":\"2025-08-26T21:57:01.583\"}]",
                                           DetallesXml = null,
                                },
            }.AsEnumerable();


            _repository.Setup(pl => pl.ListarPorVendedor(22))
                .Returns(modelo);

            var result = _service.ListarPorVendedor(22);

            result.Should().HaveCount(3);

            //result.ListarPorVendedor(22).ContainSingle(x => x.Meta_Id == 2);
        }

        //ya se explico arriba
        [Fact]

        //unit test para insertar lista precio
        public void MetasInsertar()
        {
            //declaramos un elemento a insertar (que lleve algo aunque sea)
            var item = new tbMetas { Prod_Id = 10 };

            //el insertar del repositorio con las cosas esperadas que devuelva
            _repository.Setup(pl => pl.InsertCompleto(item))
              .Returns(new RequestStatus { code_Status = 1, message_Status = "Precios registrados correctamente." });
            //

            //ejecuta el insert del service y guarda el result de este mismo
            var result = _service.InsertMetasCompleto(item);

            //success por como lo tenemos siempre dara true así que luego evaluamos lo del data que se manda desde
            //el sp en la base de datos
            result.Success.Should().BeTrue();

            //cosas del data del sp
            //si el code_Status es un entonces si se inserto, en caso que tire error es que no inserto nada
            ((int)result.Data.code_Status).Should().Be(1);
            //si el message_Status es el esperado entonces se cumplio que si inserto
            ((string)result.Data.message_Status).Should().Be("Precios registrados correctamente.");
            //validar que se llamo solo una vez durante la ejecucion
            _repository.Verify(r => r.InsertCompleto(item), Times.Once);

        }

    }
}
