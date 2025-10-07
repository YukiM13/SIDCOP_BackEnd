using FluentAssertions;
using Moq;
using SIDCOP_Backend.BusinessLogic;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.DataAccess;
using SIDCOP_Backend.DataAccess.Repositories.Acceso;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace SIDCOP.UnitTest.Acceso
{
    public class PermisoUnitTest
    {
        private readonly Mock<PermisoRepository> _repository;
        
        private readonly AccesoServices _service;

        public PermisoUnitTest()
        {
            _repository = new Mock<PermisoRepository>();

            _service = new AccesoServices(null, null,
                                        _repository.Object,
                                        null
            );
        }

        [Fact]
        public void Permisos_Listar()
        {
            var modelo = new List<tbPermisos>()
            {
                new tbPermisos { Perm_Id = 1, Role_Id = 1, AcPa_Id = 1 },
                new tbPermisos { Perm_Id = 2, Role_Id = 2, AcPa_Id = 2 },
                new tbPermisos { Perm_Id = 3, Role_Id = 3, AcPa_Id = 3 }
            }.AsEnumerable();

            _repository.Setup(pl => pl.List())
                .Returns(modelo);

            var result = _service.ListPermisos();

            result.Should().HaveCount(3);

            result.Should().ContainSingle(x => x.Perm_Id == 1);
        }

        [Fact]
        public void Permiso_Insertar()
        {
            var item = new tbPermisos { Role_Id = 1, AcPa_Id = 1 };

            _repository.Setup(pl => pl.Insert(item))
              .Returns(new RequestStatus { code_Status = 1, message_Status = "Permiso registrado correctamente." });
            var result = _service.InsertPermiso(item);

            result.Success.Should().BeTrue();

            ((int)result.Data.code_Status).Should().Be(1);
            ((string)result.Data.message_Status).Should().Be("Permiso registrado correctamente.");
            _repository.Verify(r => r.Insert(item), Times.Once);
        }

        [Fact]
        public void Permiso_Actualizar()
        {
            var item = new tbPermisos
            {
                Perm_Id = 1,
                Role_Id = 12,
                AcPa_Id = 100
            };

            _repository.Setup(r => r.Update(item))
                .Returns(new RequestStatus
                {
                    code_Status = 1,
                    message_Status = "Permiso actualizado correctamente."
                });

            // Act: llamamos al método del servicio
            var result = _service.UpdatePermiso(item);

            // Assert: validamos que el resultado sea exitoso y tenga el mensaje esperado
            result.Success.Should().BeTrue();
            ((int)result.Data.code_Status).Should().Be(1);
            ((string)result.Data.message_Status).Should().Be("Permiso actualizado correctamente.");

            // Validamos que se llamó al método Update exactamente una vez
            _repository.Verify(r => r.Update(item), Times.Once);
        }

        [Fact]
        public void Permiso_Eliminar()
        {
            var item = new tbPermisos
            {
                Perm_Id = 1
            };

            _repository.Setup(r => r.Delete(item))
                .Returns(new RequestStatus
                {
                    code_Status = 1,
                    message_Status = "Permiso eliminado correctamente."
                });

            // Act: llamamos al método del servicio
            var result = _service.EliminarPermiso(item);

            // Assert: validamos que el resultado sea exitoso y tenga el mensaje esperado
            result.Success.Should().BeTrue();
            ((int)result.Data.code_Status).Should().Be(1);
            ((string)result.Data.message_Status).Should().Be("Permiso eliminado correctamente.");

            // Validamos que se llamó al método Delete exactamente una vez
            _repository.Verify(r => r.Delete(item), Times.Once);
        }

        [Fact]
        public void Permiso_Buscar()
        {
            var item = new tbPermisos
            {
                Perm_Id = 1
            };

            _repository.Setup(r => r.FindPermission(item));

            // Act: llamamos al método del servicio
            var result = _service.BuscarPermiso(item);

            // Assert: validamos que el resultado sea exitoso y tenga el mensaje esperado
            //result.Success.Should().BeTrue();
            //((int)result.Data.code_Status).Should().Be(1);
            //((string)result.Data.message_Status).Should().Be("Permiso encontrado correctamente.");

            // Validamos que se llamó al método Delete exactamente una vez
            _repository.Verify(r => r.FindPermission(item), Times.Once);
        }
    }
}
