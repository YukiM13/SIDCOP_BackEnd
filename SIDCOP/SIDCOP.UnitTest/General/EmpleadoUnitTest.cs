using FluentAssertions;
using Moq;
using SIDCOP_Backend.BusinessLogic;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.DataAccess;
using SIDCOP_Backend.DataAccess.Repositories.General;
using SIDCOP_Backend.Entities.Entities;

namespace SIDCOP.UnitTest.General
{
    public class EmpleadoUnitTest
    {
        private readonly Mock<EmpleadoRepository> _repository;
        private readonly GeneralServices _service;

        public EmpleadoUnitTest()
        {
            _repository = new Mock<EmpleadoRepository>();

            _service = new GeneralServices(null, null, null, null, null,
                _repository.Object, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null

                                          );
        }

        [Fact]
        public void ListarEmpleado_DeberiaRetornarListaDeEmpleados()
        {
            // Arrange
            var empleadosMock = new List<tbEmpleados>
    {
        new tbEmpleados { Empl_Id = 1, Empl_Nombres = "Juan", Empl_Apellidos = "Pérez" },
        new tbEmpleados { Empl_Id = 2, Empl_Nombres = "María", Empl_Apellidos = "González" }
    }.AsQueryable();

            _repository.Setup(r => r.List()).Returns(empleadosMock);

            // Act
            var resultado = _service.ListarEmpleado();

            // Assert
            resultado.Should().NotBeNull();
            resultado.Should().HaveCount(2);
            resultado.Should().Contain(e => e.Empl_Nombres == "Juan");
            resultado.Should().Contain(e => e.Empl_Nombres == "María");
        }

        [Fact]
        public void InsertarEmpleado_DeberiaRetornarExito()
        {
            // Arrange
            var nuevoEmpleado = new tbEmpleados
            {
                Empl_Nombres = "Carlos",
                Empl_Apellidos = "López",
                Empl_DNI = "12345678",
                // ... otros campos requeridos
            };

            var resultadoEsperado = new ServiceResult();
            resultadoEsperado.Success = true;
            resultadoEsperado.Data = 1; // ID del empleado insertado

            _repository.Setup(r => r.Insert(It.IsAny<tbEmpleados>()))
                .Returns(new RequestStatus { code_Status = 1, message_Status = "Empleado insertado correctamente" });

            // Act
            var resultado = _service.InsertarEmpleados(nuevoEmpleado);

            // Assert
            resultado.Should().NotBeNull();
            resultado.Success.Should().BeTrue();
            _repository.Verify(r => r.Insert(It.IsAny<tbEmpleados>()), Times.Once);
        }

        [Fact]
        public void ActualizarEmpleado_DeberiaRetornarExito()
        {
            // Arrange
            var empleadoActualizado = new tbEmpleados
            {
                Empl_Id = 1,
                Empl_Nombres = "Carlos",
                Empl_Apellidos = "López Modificado",
                // ... otros campos
            };

            _repository.Setup(r => r.Update(It.IsAny<tbEmpleados>()))
                .Returns(new RequestStatus { code_Status = 1, message_Status = "Empleado actualizado correctamente" });

            // Act
            var resultado = _service.UpdateEmpleados(empleadoActualizado);

            // Assert
            resultado.Should().NotBeNull();
            resultado.Success.Should().BeTrue();
            _repository.Verify(r => r.Update(It.IsAny<tbEmpleados>()), Times.Once);
        }

        [Fact]
        public void EliminarEmpleado_DeberiaRetornarExito()
        {
            // Arrange
            int idEmpleado = 1;
            _repository.Setup(r => r.Delete(idEmpleado))
                .Returns(new RequestStatus { code_Status = 1, message_Status = "Empleado eliminado correctamente" });

            // Act
            var resultado = _service.DeleteEmpleado(idEmpleado);

            // Assert
            resultado.Should().NotBeNull();
            resultado.Success.Should().BeTrue();
            _repository.Verify(r => r.Delete(idEmpleado), Times.Once);
        }

        [Fact]
        public void EliminarEmpleado_ConIdInexistente_DeberiaRetornarError()
        {
            // Arrange
            int idInexistente = 999;
            _repository.Setup(r => r.Delete(idInexistente))
                .Returns(new RequestStatus { code_Status = 0, message_Status = "Empleado no encontrado" });

            // Act
            var resultado = _service.DeleteEmpleado(idInexistente);

            // Assert
            resultado.Should().NotBeNull();
            resultado.Success.Should().BeFalse();
            resultado.Message.Should().Contain("no encontrado");
        }

        [Fact]
        public void BuscarEmpleadoPorId_DeberiaRetornarEmpleado()
        {
            // Arrange
            int idEmpleado = 1;
            var empleadoEsperado = new tbEmpleados
            {
                Empl_Id = idEmpleado,
                Empl_Nombres = "Juan",
                Empl_Apellidos = "Pérez"
            };

            _repository.Setup(r => r.Find(idEmpleado)).Returns(empleadoEsperado);

            // Act
            var resultado = _service.FindEmpleados(idEmpleado);

            // Assert
            resultado.Should().NotBeNull();
            resultado.Empl_Id.Should().Be(idEmpleado);
            _repository.Verify(r => r.Find(idEmpleado), Times.Once);
        }

        [Fact]
        public void BuscarEmpleadoPorId_ConIdInexistente_DeberiaRetornarNull()
        {
            // Arrange
            int idInexistente = 999;
            _repository.Setup(r => r.Find(idInexistente)).Throws(new Exception("Empleado no encontrado"));

            // Act
            var resultado = _service.FindEmpleados(idInexistente);

            // Assert
            resultado.Should().BeNull();
        }
    }
}