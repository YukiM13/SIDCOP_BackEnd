using Moq;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.DataAccess.Repositories.General;
using SIDCOP_Backend.DataAccess;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

    namespace SIDCOP.UnitTest.General
    {
        public class ProveedoresTest
        {
            private readonly Mock<ProveedoresRepository> _repository;
            private readonly GeneralServices _service;

            public ProveedoresTest()
            {
                _repository = new Mock<ProveedoresRepository>();

                // Ajusta la posición del repositorio según cómo esté declarado en tu GeneralServices
                _service = new GeneralServices(
                    null, null, null, null, null, null, null, null, null, null, null,
                    _repository.Object, // Repositorio de proveedores
                    null, null, null, null, null, null, null, null,
                    null, null, null
                );
            } 


            [Fact]
            public void ProveedoresListar_DeberiaRetornarListaCorrecta()
            {
                // Arrange
                var modelo = new List<tbProveedores>()
            {
                new tbProveedores
                {
                    Prov_Id = 1,
                    Prov_Codigo = "PROV-0001",
                    Prov_NombreEmpresa = "Ferretería Central",
                    Prov_NombreContacto = "Carlos Rivera",
                    Prov_Telefono = "2233-4455",
                    Prov_Correo = "ventas@ferreteriacentral.hn"
                },
                new tbProveedores
                {
                    Prov_Id = 2,
                    Prov_Codigo = "PROV-0002",
                    Prov_NombreEmpresa = "Distribuidora López",
                    Prov_NombreContacto = "María López",
                    Prov_Telefono = "9988-7766",
                    Prov_Correo = "contacto@distribuidoralopez.hn"
                }
            }.AsEnumerable();

                _repository.Setup(repo => repo.List()).Returns(modelo);

                // Act
                var result = _service.ListProveedores();

                // Assert
                result.Should().HaveCount(2);
                result.Should().ContainSingle(p => p.Prov_NombreEmpresa == "Ferretería Central");
            }

       
            [Fact]
            public void ProveedoresInsertar_DeberiaRetornarExito()
            {
                // Arrange
                var nuevo = new tbProveedores
                {
                    Prov_Codigo = "PROV-0003",
                    Prov_NombreEmpresa = "Importadora Martínez",
                    Prov_NombreContacto = "José Martínez",
                    Prov_Telefono = "8877-6655",
                    Prov_Correo = "info@importadoramartinez.hn",
                    Usua_Creacion = 1
                };


                _repository.Setup(repo => repo.Insert(It.IsAny<tbProveedores>()));

                // Act
                var resultado = _service.InsertarProveedor(nuevo);

                 // Assert
                resultado.Should().NotBeNull();
                resultado.Success.Should().BeTrue();
                _repository.Verify(r => r.Insert(It.IsAny<tbProveedores>()), Times.Once);
        }

            [Fact]
            public void ProveedoresActualizar_DeberiaRetornarExito()
            {
                // Arrange
                var proveedor = new tbProveedores
                {
                    Prov_Id = 1,
                    Prov_Codigo = "PROV-0001",
                    Prov_NombreEmpresa = "Ferretería Central Actualizada",
                    Prov_NombreContacto = "Carlos Rivera",
                    Prov_Telefono = "2233-4455",
                    Prov_Correo = "ventas@ferreteriacentral.hn",
                    Usua_Modificacion = 2
                };

            

                _repository.Setup(repo => repo.Update(It.IsAny<tbProveedores>()));

                // Act
                var resultado = _service.ActualizarProveedor(proveedor);

                resultado.Should().NotBeNull();
                resultado.Success.Should().BeTrue();
                _repository.Verify(r => r.Update(It.IsAny<tbProveedores>()), Times.Once);
        }

   
            [Fact]
            public void ProveedoresEliminar_DeberiaRetornarExito()
            {
                // Arrange
                int id = 1;
          

                _repository.Setup(repo => repo.Delete(id));

                // Act
                var resultado = _service.EliminarProveedor(id);

                // Assert
                resultado.Should().NotBeNull();
                resultado.Success.Should().BeTrue();
                _repository.Verify(r => r.Delete(id), Times.Once);
        
        }
    }

}

