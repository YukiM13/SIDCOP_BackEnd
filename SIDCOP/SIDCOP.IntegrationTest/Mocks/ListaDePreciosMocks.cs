using Api_SIDCOP.API.Models.Ventas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP.IntegrationTest.Mocks
{
    public class ListaDePreciosMocks
    {
        public static PreciosPorProductoViewModel CrearMockPreciosPorProducto()
        {
            return new PreciosPorProductoViewModel
            {
                Prod_Id = 1,
                Clie_Id = 1,
                PreP_PrecioContado = 150.50m,
                PreP_PrecioCredito = 175.75m,
                PreP_InicioEscala = 1,
                PreP_FinEscala = 10,
                PreP_ListaPrecios = 1,
                Usua_Creacion = 1,
                PreP_FechaCreacion = DateTime.Now,
                PreP_Estado = true,
                ClientesXml = "<Clientes><Cliente><Id>1</Id></Cliente></Clientes>"
            };
        }

        public static PreciosPorProductoViewModel CrearMockPreciosPorProductoParaActualizar()
        {
            return new PreciosPorProductoViewModel
            {
                PreP_Id = 1,
                Prod_Id = 1,
                Clie_Id = 1,
                PreP_PrecioContado = 200.00m,
                PreP_PrecioCredito = 225.00m,
                PreP_InicioEscala = 1,
                PreP_FinEscala = 15,
                PreP_ListaPrecios = 1,
                Usua_Creacion = 1,
                PreP_FechaCreacion = DateTime.Now,
                Usua_Modificacion = 1,
                PreP_FechaModificacion = DateTime.Now,
                PreP_Estado = true,
                ClientesXml = "<Clientes><Cliente><Id>1</Id></Cliente></Clientes>"
            };
        }

        /// <summary>
        /// Crea datos inválidos para probar el manejo de errores del sistema
        /// Contiene múltiples problemas que deberían causar que la API falle
        /// </summary>
        public static PreciosPorProductoViewModel CrearMockPreciosPorProductoInvalidos()
        {
            return new PreciosPorProductoViewModel
            {
                // IDs negativos o inválidos
                Prod_Id = -1,
                Clie_Id = -999,
                
                // Precios negativos (no válidos para un negocio)
                PreP_PrecioContado = -50.00m,
                PreP_PrecioCredito = -75.00m,
                
                // Escala inválida (fin menor que inicio)
                PreP_InicioEscala = 10,
                PreP_FinEscala = 5,
                
                // Lista de precios inválida
                PreP_ListaPrecios = -1,
                
                // Usuario inválido
                Usua_Creacion = -1,
                
                // Fecha futura (podría no ser válida según reglas de negocio)
                PreP_FechaCreacion = DateTime.Now.AddYears(10),
                
                // Estado inválido podría ser null en algunos casos
                PreP_Estado = false,
                
                // XML malformado
                ClientesXml = "<Clientes><Cliente><Id>INVALID_ID</Cliente></Clientes>"
            };
        }

        /// <summary>
        /// Crea datos con valores extremos para probar límites del sistema
        /// </summary>
        public static PreciosPorProductoViewModel CrearMockPreciosPorProductoValoresExtremos()
        {
            return new PreciosPorProductoViewModel
            {
                // IDs con valores extremos
                Prod_Id = int.MaxValue,
                Clie_Id = 0, // ID cero que podría no existir
                
                // Precios con valores extremos
                PreP_PrecioContado = decimal.MaxValue,
                PreP_PrecioCredito = 0.00m, // Precio cero
                
                // Escalas con valores extremos
                PreP_InicioEscala = int.MaxValue,
                PreP_FinEscala = int.MaxValue,
                
                // Lista de precios inexistente
                PreP_ListaPrecios = 99999,
                
                // Usuario inexistente
                Usua_Creacion = 99999,
                
                // Fecha muy antigua
                PreP_FechaCreacion = DateTime.MinValue,
                
                PreP_Estado = true,
                
                // XML vacío
                ClientesXml = ""
            };
        }
    }
}
