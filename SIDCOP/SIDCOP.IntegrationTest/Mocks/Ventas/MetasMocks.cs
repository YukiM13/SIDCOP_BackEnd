using Api_SIDCOP.API.Models.Ventas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP.IntegrationTest.Mocks.Ventas
{
    public class MetasMocks
    {
        public static MetasViewModel CrearMockMeta()
        {
            return new MetasViewModel
            {
                Meta_Id = 1, // Nuevo registro, ID se asignará automáticamente
                Meta_Descripcion = "Meta de ventas Q1 2024",
                Meta_Ingresos = 50000.00m,
                Meta_FechaInicio = new DateTime(2025, 1, 1),
                Meta_FechaFin = new DateTime(2025, 12, 31),
                Meta_Tipo = "IT",
                Meta_Unidades = 0,
                Usua_Creacion = 1, // ID del usuario que crea la meta
                Meta_FechaCreacion = DateTime.Now,
                Meta_Estado = true // Activa por defecto
            };
        }

        public static MetasViewModel ActualizarMockMeta()
        {
            return new MetasViewModel
            {
                Meta_Id = 1, // Nuevo registro, ID se asignará automáticamente
                Meta_Descripcion = "Meta de ventas Q1 2024",
                Meta_Ingresos = 55000.00m,
                Meta_FechaInicio = new DateTime(2025, 1, 1),
                Meta_FechaFin = new DateTime(2025, 12, 31),
                Meta_Tipo = "IT",
                Meta_Unidades = 0,
                Usua_Creacion = 1, // ID del usuario que crea la meta
                Meta_FechaCreacion = DateTime.Now,
                Meta_Estado = true // Activa por defecto
            };
        }

        public static MetasViewModel CrearMockMetaValoresExtremos()
        {
            return new MetasViewModel
            {
                Meta_Id = int.MaxValue, // Nuevo registro, ID se asignará automáticamente
                Meta_Descripcion = "Meta de ventas Q1 2024",
                Meta_Ingresos = int.MaxValue,
                Meta_FechaInicio = new DateTime(2025, 1, 1),
                Meta_FechaFin = new DateTime(2025, 12, 31),
                Meta_Tipo = "IT",
                Meta_Unidades = int.MaxValue,
                Usua_Creacion = 99999, // ID del usuario que crea la meta
                Meta_FechaCreacion = DateTime.MinValue,
                Meta_Estado = true // Activa por defecto
            };
        }

        public static MetasViewModel CrearMockMetaInvalidos()
        {
            return new MetasViewModel
            {
                // ID negativo (no válido para un nuevo registro)
                Meta_Id = -1,

                // Descripción vacía (debería ser obligatoria)
                Meta_Descripcion = "",

                // Monto negativo (no válido para una meta de ventas)
                Meta_Ingresos = -1000.00m,

                // Fecha de inicio posterior a la fecha de fin (lógica inválida)
                Meta_FechaInicio = new DateTime(2024, 12, 31),
                Meta_FechaFin = new DateTime(2024, 1, 1),

                // Usuario inválido
                Usua_Creacion = -1,

                // Fecha futura (podría no ser válida según reglas de negocio)
                Meta_FechaCreacion = DateTime.Now.AddYears(10),

                Meta_Tipo = "",
                Meta_Unidades = -1,

                // Estado inválido podría ser null en algunos casos
                Meta_Estado = false
            };
        }

    }
}
