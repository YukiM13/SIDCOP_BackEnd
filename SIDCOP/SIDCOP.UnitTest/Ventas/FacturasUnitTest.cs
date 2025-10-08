using Moq;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.DataAccess.Repositories.Ventas;
using SIDCOP_Backend.DataAccess;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace SIDCOP.UnitTest.Ventas
{
    public class FacturasUnitTest
    {
        // Repositorio que se usará haciéndolo con mock
        private readonly Mock<FacturasRepository> _repository;
        // Service que usa ese repositorio
        private readonly VentaServices _service;

        // Prepara el entorno de pruebas
        public FacturasUnitTest()
        {
            // Crear un mock del repositorio para no usar la bdd
            _repository = new Mock<FacturasRepository>();

            // Service - ajusta los null según la posición del repositorio en tu VentaServices
            // Ejemplo: si FacturasRepository está en la posición 11
            _service = new VentaServices(
                null, null, null, null, null, null, null, null, _repository.Object, null, null,
                null, null, null
            );
        }

        #region Pruebas de Listar

        [Fact]
        public void FacturasListar()
        {
            // Declaración de una lista de facturas (al menos 3 para verificar funcionalidad)
            var modelo = new List<tbFacturas>()
        {
            new tbFacturas
            {
                Fact_Id = 1,
                Fact_Numero = "FAC-001-001-00000001",
                Fact_TipoDeDocumento = "01",
                RegC_Id = 1,
                DiCl_Id = 1,
                Vend_Id = 1,
                Fact_TipoVenta = "CR",
                Fact_Total = 1000.50m
            },
            new tbFacturas
            {
                Fact_Id = 2,
                Fact_Numero = "FAC-001-001-00000002",
                Fact_TipoDeDocumento = "01",
                RegC_Id = 1,
                DiCl_Id = 2,
                Vend_Id = 1,
                Fact_TipoVenta = "CO",
                Fact_Total = 2500.75m
            },
            new tbFacturas
            {
                Fact_Id = 3,
                Fact_Numero = "FAC-001-001-00000003",
                Fact_TipoDeDocumento = "01",
                RegC_Id = 1,
                DiCl_Id = 1,
                Vend_Id = 2,
                Fact_TipoVenta = "CO",
                Fact_Total = 500.00m
            }
        }.AsEnumerable();

            // Esto ejecuta la función del repositorio
            _repository.Setup(f => f.List())
                .Returns(modelo);

            // Ejecutando el service y guardando el resultado
            var result = _service.ListFacturas();

            // Acceder a los datos del resultado
            var data = result.Data as IEnumerable<tbFacturas>;

            // Cantidad de objetos esperada
            data.Should().HaveCount(3);

            // Un registro que contenga algo específico y no se repita
            data.Should().ContainSingle(x => x.Fact_Id == 2);
            data.Should().ContainSingle(x => x.Fact_Numero == "FAC-001-001-00000001");
        }

        [Fact]
        public void FacturasListarPorDevoLimite()
        {
            // Lista de facturas con devoluciones próximas al límite
            var modelo = new List<tbFacturas>()
        {
            new tbFacturas
            {
                Fact_Id = 10,
                Fact_Numero = "FAC-001-001-00000010",
                Fact_FechaEmision = DateTime.Now.AddDays(-25),
                Fact_Total = 3000.00m
            },
            new tbFacturas
            {
                Fact_Id = 11,
                Fact_Numero = "FAC-001-001-00000011",
                Fact_FechaEmision = DateTime.Now.AddDays(-28),
                Fact_Total = 1500.00m
            },
            new tbFacturas
            {
                Fact_Id = 12,
                Fact_Numero = "FAC-001-001-00000012",
                Fact_FechaEmision = DateTime.Now.AddDays(-27),
                Fact_Total = 2200.00m
            }
        }.AsEnumerable();

            _repository.Setup(f => f.ListPorDevoLimite())
                .Returns(modelo);

            var result = _service.ListFacturasDevoLimite();

            // Acceder a los datos del resultado
            var data = result.Data as IEnumerable<tbFacturas>;

            data.Should().HaveCount(3);
            data.Should().ContainSingle(x => x.Fact_Id == 11);
        }

        #endregion

        #region Pruebas de Insertar

        [Fact]
        public void FacturaInsertarVenta()
        {
            // Declaramos un elemento a insertar
            var item = new VentaInsertarDTO
            {
                Fact_Numero = "FAC-001-001-00000050",
                Fact_TipoDeDocumento = "1",
                RegC_Id = 1,
                DiCl_Id = 1,
                Vend_Id = 1,
                Fact_TipoVenta = "CONTADO",
                Fact_FechaEmision = DateTime.Now,
                Usua_Creacion = 1,
                DetallesFacturaInput = new List<VentaDetalleDTO>
            {
                new VentaDetalleDTO { Prod_Id = 1, FaDe_Cantidad = 5 }
            }
            };

            // El insertar del repositorio con las cosas esperadas que devuelva
            _repository.Setup(f => f.InsertarVenta(item))
                .Returns(new RequestStatus
                {
                    code_Status = 1,
                    message_Status = "Venta insertada correctamente. ID: 50."
                });

            // Ejecuta el insert del service y guarda el resultado
            var result = _service.InsertVentas(item);

            // Success siempre dará true así que evaluamos el data del SP
            result.Success.Should().BeTrue();

            // Cosas del data del SP
            var data = result.Data as RequestStatus;
            data.Should().NotBeNull();
            ((int)data.code_Status).Should().Be(1);
            ((string)data.message_Status).Should().Contain("Venta insertada correctamente");

            // Validar que se llamó solo una vez durante la ejecución
            _repository.Verify(r => r.InsertarVenta(item), Times.Once);
        }

        [Fact]
        public void FacturaInsertarVentaEnSucursal()
        {
            var item = new VentaInsertarDTO
            {
                Fact_TipoDeDocumento = "1",
                RegC_Id = 1,
                DiCl_Id = 1,
                Vend_Id = 1,
                Fact_TipoVenta = "CREDITO",
                Fact_FechaEmision = DateTime.Now,
                Usua_Creacion = 1,
                DetallesFacturaInput = new List<VentaDetalleDTO>
            {
                new VentaDetalleDTO { Prod_Id = 2, FaDe_Cantidad = 10 }
            }
            };

            _repository.Setup(f => f.InsertarVentaEnSucursal(item))
                .Returns(new RequestStatus
                {
                    code_Status = 1,
                    message_Status = "Venta insertada correctamente. Número: FAC-002-001-00000001, ID: 100."
                });

            var result = _service.InsertVentasSucursal(item);

            result.Success.Should().BeTrue();

            var data = result.Data as RequestStatus;
            data.Should().NotBeNull();
            ((int)data.code_Status).Should().Be(1);
            ((string)data.message_Status).Should().Contain("Número: FAC-002-001-00000001");

            _repository.Verify(r => r.InsertarVentaEnSucursal(item), Times.Once);
        }

        [Fact]
        public void FacturaInsertarVentaSinDetalles()
        {
            var item = new VentaInsertarDTO
            {
                Fact_Numero = "FAC-001-001-00000050",
                Fact_TipoDeDocumento = "1",
                RegC_Id = 1,
                DiCl_Id = 1,
                Vend_Id = 1,
                Fact_TipoVenta = "CONTADO",
                Fact_FechaEmision = DateTime.Now,
                Usua_Creacion = 1,
                DetallesFacturaInput = new List<VentaDetalleDTO>() // Lista vacía
            };

            var result = _service.InsertVentas(item);

            result.Success.Should().BeFalse();
            result.Message.Should().Contain("al menos un producto");

            // No debe llamar al repositorio si falla la validación
            _repository.Verify(r => r.InsertarVenta(It.IsAny<VentaInsertarDTO>()), Times.Never);
        }

        [Fact]
        public void FacturaInsertarVentaConDatosInvalidos()
        {
            var item = new VentaInsertarDTO
            {
                Fact_Numero = "FAC-001-001-00000050",
                Fact_TipoDeDocumento = "1",
                RegC_Id = 1,
                DiCl_Id = 1,
                Vend_Id = 1,
                Fact_TipoVenta = "CONTADO",
                Fact_FechaEmision = DateTime.Now,
                Usua_Creacion = 1,
                DetallesFacturaInput = new List<VentaDetalleDTO>
            {
                new VentaDetalleDTO { Prod_Id = 0, FaDe_Cantidad = 5 }, // ID inválido
                new VentaDetalleDTO { Prod_Id = 2, FaDe_Cantidad = -1 }  // Cantidad inválida
            }
            };

            var result = _service.InsertVentas(item);

            result.Success.Should().BeFalse();
            result.Message.Should().Contain("ID válido y cantidad mayor a 0");

            _repository.Verify(r => r.InsertarVenta(It.IsAny<VentaInsertarDTO>()), Times.Never);
        }

        #endregion

        #region Pruebas de Obtener Factura Completa

        [Fact]
        public void FacturaObtenerCompleta()
        {
            // Preparar datos completos de una factura
            var facturaCompleta = new FacturaCompletaDTO
            {
                // Configuración empresa
                CoFa_NombreEmpresa = "Empresa Test S.A.",
                CoFa_RTN = "08011990123456",

                // Datos factura
                Fact_Id = 1,
                Fact_Numero = "FAC-001-001-00000001",
                Fact_TipoDeDocumento = "01",
                Fact_TipoVenta ="CO",
                Fact_Total = 1150.00m,

                // Cliente
                Clie_Id = 1,
                Cliente = "Cliente Test",

                // Vendedor
                Vend_Id = 1,
                Vendedor = "Vendedor Test",

                // Detalles
                DetalleFactura = new List<FacturaCompletaDTO.DetalleItem>
            {
                new FacturaCompletaDTO.DetalleItem
                {
                    FaDe_Id = 1,
                    Prod_Id = 1,
                    Prod_Descripcion = "Producto Test",
                    FaDe_Cantidad = 10,
                    FaDe_PrecioUnitario = 100.00m,
                    FaDe_Total = 1000.00m
                }
            },

                Mensaje = "Factura obtenida correctamente",
                Exitoso = true
            };

            _repository.Setup(f => f.ObtenerFacturaCompleta(1))
                .Returns(facturaCompleta);

            var result = _service.ObtenerFacturaCompleta(1);

            // Acceder a los datos del resultado
            var data = result.Data as FacturaCompletaDTO;

            data.Should().NotBeNull();
            data.Exitoso.Should().BeTrue();
            data.Fact_Id.Should().Be(1);
            data.Fact_Numero.Should().Be("FAC-001-001-00000001");
            data.DetalleFactura.Should().HaveCount(1);
            data.DetalleFactura.Should().ContainSingle(x => x.Prod_Id == 1);

            _repository.Verify(r => r.ObtenerFacturaCompleta(1), Times.Once);
        }

        #endregion

        #region Pruebas de Listar por Vendedor

        [Fact]
        public void FacturasListarPorVendedor()
        {
            var modelo = new List<FacturaVendedorDTO>()
        {
            new FacturaVendedorDTO
            {
                Fact_Id = 1,
                Fact_Numero = "FAC-001-001-00000001",
                Cliente = "Cliente A",
                Fact_Total = 1000.00m,
                Exitoso = true
            },
            new FacturaVendedorDTO
            {
                Fact_Id = 2,
                Fact_Numero = "FAC-001-001-00000002",
                Cliente = "Cliente B",
                Fact_Total = 2000.00m,
                Exitoso = true
            },
            new FacturaVendedorDTO
            {
                Fact_Id = 3,
                Fact_Numero = "FAC-001-001-00000003",
                Cliente = "Cliente C",
                Fact_Total = 1500.00m,
                Exitoso = true
            }
        }.ToList();

            _repository.Setup(f => f.ListarFacturasPorVendedor(5))
                .Returns(modelo);

            var result = _service.ListarFacturasPorVendedor(5);

            // Acceder a los datos del resultado
            var data = result.Data as List<FacturaVendedorDTO>;

            data.Should().HaveCount(3);
            data.Should().ContainSingle(x => x.Fact_Id == 2);
            data.Should().OnlyContain(x => x.Exitoso == true);

            _repository.Verify(r => r.ListarFacturasPorVendedor(5), Times.Once);
        }

        #endregion

        #region Pruebas de Anular

        [Fact]
        public void FacturaAnular()
        {
            var item = new tbFacturas
            {
                Fact_Id = 10,
                Usua_Modificacion = 1,
                Motivo = "Factura duplicada"
            };

            _repository.Setup(f => f.AnularFactura(item))
                .Returns(new RequestStatus
                {
                    code_Status = 1,
                    message_Status = "Factura anulada correctamente"
                });

            var result = _service.AnularFactura(item);

            result.Success.Should().BeTrue();
            ((int)result.Data.code_Status).Should().Be(1);
            ((string)result.Data.message_Status).Should().Contain("anulada correctamente");

            _repository.Verify(r => r.AnularFactura(item), Times.Once);
        }

        [Fact]
        public void FacturaAnularError()
        {
            var item = new tbFacturas
            {
                Fact_Id = 999,
                Usua_Modificacion = 1,
                Motivo = "Factura inexistente"
            };

            _repository.Setup(f => f.AnularFactura(item))
                .Returns(new RequestStatus
                {
                    code_Status = 0,
                    message_Status = "Error: La factura no existe"
                });

            var result = _service.AnularFactura(item);

            result.Code.Should().Be(200);
            ((int)result.Data.code_Status).Should().Be(0);
            ((string)result.Data.message_Status).Should().Contain("Error");

            _repository.Verify(r => r.AnularFactura(item), Times.Once);
        }

        #endregion
    }
}
