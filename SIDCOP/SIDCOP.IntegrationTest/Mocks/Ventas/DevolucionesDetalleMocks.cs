using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;

namespace SIDCOP.IntegrationTest.Mocks.Ventas
{
    public static class DevolucionesDetalleMocks
    {
        /// <summary>
        /// Crea un ID válido para buscar detalles de devolución
        /// Este ID debería existir en la base de datos de pruebas
        /// </summary>
        /// <returns>ID válido para búsqueda</returns>
        public static int CrearIdValidoParaBuscar()
        {
            // Retorna un ID que probablemente exista en la base de datos
            // En un entorno real, este ID debería ser configurado según los datos de prueba
            return 1;
        }

        /// <summary>
        /// Crea un ID inválido para probar el manejo de errores
        /// Este ID no debería existir en la base de datos
        /// </summary>
        /// <returns>ID inválido para búsqueda</returns>
        public static int CrearIdInvalidoParaBuscar()
        {
            // Retorna un ID que probablemente no exista en la base de datos
            return 999999;
        }

        /// <summary>
        /// Crea un mock válido para insertar detalle de devolución
        /// Nota: El controlador actual no tiene endpoint de insertar, pero se incluye para consistencia
        /// </summary>
        /// <returns>Objeto tbDevolucionesDetalle válido para inserción</returns>
        public static tbDevolucionesDetalle CrearMockValidoParaInsertar()
        {
            return new tbDevolucionesDetalle
            {
                Devo_Id = 1,
                Prod_Id = 10,
                DevD_Cantidad = 2,
                Usua_Creacion = 1,
                DevD_FechaCreacion = DateTime.Now,
                DevD_Estado = true
            };
        }

        /// <summary>
        /// Crea un mock válido para actualizar detalle de devolución
        /// Nota: El controlador actual no tiene endpoint de actualizar, pero se incluye para consistencia
        /// </summary>
        /// <returns>Objeto tbDevolucionesDetalle válido para actualización</returns>
        public static tbDevolucionesDetalle CrearMockValidoParaActualizar()
        {
            return new tbDevolucionesDetalle
            {
                DevD_Id = 1,
                Devo_Id = 1,
                Prod_Id = 15,
                DevD_Cantidad = 3,
                Usua_Creacion = 1,
                DevD_FechaCreacion = DateTime.Now.AddDays(-1),
                Usua_Modificacion = 2,
                DevD_FechaModificacion = DateTime.Now,
                DevD_Estado = true
            };
        }

        /// <summary>
        /// Crea un mock con valores extremos para probar límites del sistema
        /// </summary>
        /// <returns>Objeto tbDevolucionesDetalle con valores extremos</returns>
        public static tbDevolucionesDetalle CrearMockConValoresExtremos()
        {
            return new tbDevolucionesDetalle
            {
                DevD_Id = int.MaxValue,
                Devo_Id = int.MaxValue,
                Prod_Id = int.MaxValue,
                DevD_Cantidad = int.MaxValue,
                Usua_Creacion = int.MaxValue,
                DevD_FechaCreacion = DateTime.MaxValue,
                Usua_Modificacion = int.MaxValue,
                DevD_FechaModificacion = DateTime.MaxValue,
                DevD_Estado = true
            };
        }

        /// <summary>
        /// Crea un mock con datos inválidos para probar validaciones
        /// </summary>
        /// <returns>Objeto tbDevolucionesDetalle con datos inválidos</returns>
        public static tbDevolucionesDetalle CrearMockConDatosInvalidos()
        {
            return new tbDevolucionesDetalle
            {
                DevD_Id = -1,
                Devo_Id = 0, // ID inválido
                Prod_Id = -5, // ID inválido
                DevD_Cantidad = -10, // Cantidad negativa
                Usua_Creacion = 0, // Usuario inválido
                DevD_FechaCreacion = DateTime.MinValue, // Fecha muy antigua
                Usua_Modificacion = -1, // Usuario inválido
                DevD_FechaModificacion = DateTime.MinValue,
                DevD_Estado = false
            };
        }

        /// <summary>
        /// Crea una lista de detalles de devolución para pruebas que requieren múltiples elementos
        /// </summary>
        /// <returns>Lista de objetos tbDevolucionesDetalle</returns>
        public static List<tbDevolucionesDetalle> CrearListaMockDetalles()
        {
            return new List<tbDevolucionesDetalle>
            {
                new tbDevolucionesDetalle
                {
                    DevD_Id = 1,
                    Devo_Id = 1,
                    Prod_Id = 10,
                    DevD_Cantidad = 2,
                    Usua_Creacion = 1,
                    DevD_FechaCreacion = DateTime.Now.AddDays(-2),
                    DevD_Estado = true,
                    Prod_Descripcion = "Producto Test 1",
                    UsuarioCreacion = "Usuario Test"
                },
                new tbDevolucionesDetalle
                {
                    DevD_Id = 2,
                    Devo_Id = 1,
                    Prod_Id = 20,
                    DevD_Cantidad = 1,
                    Usua_Creacion = 1,
                    DevD_FechaCreacion = DateTime.Now.AddDays(-2),
                    DevD_Estado = true,
                    Prod_Descripcion = "Producto Test 2",
                    UsuarioCreacion = "Usuario Test"
                },
                new tbDevolucionesDetalle
                {
                    DevD_Id = 3,
                    Devo_Id = 1,
                    Prod_Id = 30,
                    DevD_Cantidad = 3,
                    Usua_Creacion = 1,
                    DevD_FechaCreacion = DateTime.Now.AddDays(-2),
                    DevD_Estado = true,
                    Prod_Descripcion = "Producto Test 3",
                    UsuarioCreacion = "Usuario Test"
                }
            };
        }

        /// <summary>
        /// Crea un mock de detalle con información extendida (incluyendo campos NotMapped)
        /// </summary>
        /// <returns>Objeto tbDevolucionesDetalle con información completa</returns>
        public static tbDevolucionesDetalle CrearMockDetalleCompleto()
        {
            return new tbDevolucionesDetalle
            {
                DevD_Id = 1,
                Devo_Id = 1,
                Prod_Id = 10,
                DevD_Cantidad = 2,
                Usua_Creacion = 1,
                DevD_FechaCreacion = DateTime.Now.AddDays(-1),
                DevD_Estado = true,
                
                // Campos NotMapped para información adicional
                Secuencia = 1,
                Cate_Descripcion = "Categoría Test",
                Subc_Descripcion = "Subcategoría Test",
                Prod_Imagen = "imagen_test.jpg",
                Prod_Descripcion = "Producto de prueba para devolución",
                Productos_Devueltos = "2 unidades devueltas",
                Prod_DescripcionCorta = "Prod Test",
                UsuarioCreacion = "Admin Test",
                UsuarioModificacion = null
            };
        }
    }
}
