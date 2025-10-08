using FluentAssertions;
using Moq;
using SIDCOP_Backend.BusinessLogic;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.DataAccess;
using SIDCOP_Backend.DataAccess.Repositories.General;
using SIDCOP_Backend.DataAccess.Repositories.Ventas;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP.UnitTest.General
{
    public class ClienteTest
    {
        //repositorio que se usara haciendolo con mock (explicacion mas abajo)
        private readonly Mock<ClienteRepository> _repository;
        //service que usa ese repositorio
        private readonly GeneralServices _service;

        public ClienteTest()
        {
            //crear un mock del repositorio para no usar la bdd, aqui podemos controlar
            //que devuelve cada funcion del repositorio

            _repository = new Mock<ClienteRepository>();

            //service con lo que se explica abajo usando el repo declarado arriba
            //9, 4 tiene que ir segun el lugar esta en el service 
            /*
            si el serivce esta
            cais {...}
            ventas {...}
            precioproductos {...}
            pedidos {...}
            tendrían que ir 2 null antes de ponerlo y 1 despues
            */
            _service = new GeneralServices(null, null, null, _repository.Object, null, null, null, null, null,
                                        null,
                                        null, null, null, null, null, null, null, null, null, null, null, null, null
            );
        }
        //marca el metodo que le sigue como una prueba unitaria (xunit) que no toma argumentos y que representa un solo caso de prueba
        [Fact]
            //unit test del listar
            public void ClientesListar()
            {
                //declaracion de un lista de la tabla que se usará (llenar datos al menos 3 para cerciorarse
                //que todo funcione bien
                var modelo = new List<tbClientes>()
            {
                new tbClientes {
        Clie_Id = 1,
        Clie_Codigo = "CLIE-0829",
        Clie_Nacionalidad = "Honduras",
        Clie_DNI = "0801-1990-12345",
        Clie_RTN = "08011990123456",
        Clie_Nombres = "Juan",
        Clie_Apellidos = "Pérez",
        Clie_NombreNegocio = "Comercial Pérez",
        Clie_ImagenDelNegocio = null,
        Clie_Telefono = "9999-9999",
        Clie_Correo = "juan.perez@example.com",
        Clie_Sexo = "M",
        Clie_FechaNacimiento = new DateTime(1990, 1, 15),
        TiVi_Id = 1,
        Cana_Id = 1,
        EsCv_Id = 1,
        Ruta_Id = 1,
        Clie_LimiteCredito = 10000m,
        Clie_DiasCredito = 30,
        Clie_Saldo = 0m,
        Clie_Vencido = false,
        Clie_Observaciones = null,
        Clie_ObservacionRetiro = null,
        Clie_Confirmacion = true,
        Usua_Modificacion = 1,
        Clie_FechaModificacion = DateTime.Now
    },
    new tbClientes {
        Clie_Id = 2,
        Clie_Codigo = "CLIE-0830",
        Clie_Nacionalidad = "Honduras",
        Clie_DNI = "0801-1985-67890",
        Clie_RTN = "08011985678901",
        Clie_Nombres = "María",
        Clie_Apellidos = "López",
        Clie_NombreNegocio = "Tienda López",
        Clie_ImagenDelNegocio = null,
        Clie_Telefono = "8888-8888",
        Clie_Correo = "maria.lopez@example.com",
        Clie_Sexo = "F",
        Clie_FechaNacimiento = new DateTime(1985, 5, 20),
        TiVi_Id = 2,
        Cana_Id = 1,
        EsCv_Id = 1,
        Ruta_Id = 2,
        Clie_LimiteCredito = 15000m,
        Clie_DiasCredito = 45,
        Clie_Saldo = 0m,
        Clie_Vencido = false,
        Clie_Observaciones = null,
        Clie_ObservacionRetiro = null,
        Clie_Confirmacion = true,
        Usua_Modificacion = 1,
        Clie_FechaModificacion = DateTime.Now
    },
    new tbClientes {
        Clie_Id = 3,
        Clie_Codigo = "CLIE-0831",
        Clie_Nacionalidad = "Honduras",
        Clie_DNI = "0801-1992-11111",
        Clie_RTN = "08011992111111",
        Clie_Nombres = "Carlos",
        Clie_Apellidos = "Martínez",
        Clie_NombreNegocio = "Supermercado Martínez",
        Clie_ImagenDelNegocio = null,
        Clie_Telefono = "7777-7777",
        Clie_Correo = "carlos.martinez@example.com",
        Clie_Sexo = "M",
        Clie_FechaNacimiento = new DateTime(1992, 8, 10),
        TiVi_Id = 1,
        Cana_Id = 2,
        EsCv_Id = 1,
        Ruta_Id = 1,
        Clie_LimiteCredito = 20000m,
        Clie_DiasCredito = 60,
        Clie_Saldo = 0m,
        Clie_Vencido = false,
        Clie_Observaciones = null,
        Clie_ObservacionRetiro = null,
        Clie_Confirmacion = true,
        Usua_Modificacion = 1,
        Clie_FechaModificacion = DateTime.Now
    }
}.AsEnumerable();

                //el numero es según la cantidad de objetos que le hayamos puesto a la tabla de arriba dado que es el
                //"resultado esperado"
                //esto ejecuta la funcion del repositorio
                _repository.Setup(pl => pl.ListConfirmados())
                    .Returns(modelo);

                //lo mismo aqui del "resultado esperado" ejecutando el service esta vez y guardando el result
                var result = _service.ListClientesConfirmados();

                //cantidad de objetos esperada
                result.Should().HaveCount(3);

                //un registor que contenga algo en especifico y no se repita (sirve mas que nada para las pk)

            }
        }

    }

