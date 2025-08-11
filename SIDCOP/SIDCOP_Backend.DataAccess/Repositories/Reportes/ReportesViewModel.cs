using SIDCOP_Backend.Entities.Entities;
using System.ComponentModel.DataAnnotations.Schema;


namespace Api_SIDCOP.API.Models.Reportes
{
    public class ReportesViewModel
    {
        #region ReporteProductos
        public int Prod_Id { get; set; }
        public string Prod_Codigo { get; set; }
        public string Prod_CodigoBarra { get; set; }
        public string Prod_Descripcion { get; set; }
        public string Prod_Imagen { get; set; }
        public double Prod_PrecioUnitario { get; set; }
        public double Prod_CostoTotal { get; set; }
        public string Marc_Descripcion { get; set; }      
        public string Cate_Descripcion { get; set; }
        public string Subc_Descripcion { get; set; }      
        public string Prov_NombreEmpresa { get; set; }
        public string Impu_Descripcion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime Prod_FechaCreacion { get; set; }


        #endregion

        #region ReportesClientesMasFacturados
        public int Clie_Id { get; set; }

        public string Clie_Nombres { get; set; }

        public string Clie_Apellidos { get; set; }

        public string Clie_NombreNegocio { get; set; }

        public string Clie_Telefono { get; set; }

        public string TotalFacturado { get; set; }

        public string CantidadCompras { get; set; }

        #endregion

        #region ReporteRecargasPorBodega
        public int Reca_Id { get; set; }

        public string? Recarga { get; set; }

        public int Vend_Id { get; set; }

        public int Bode_Id { get; set; }

        public DateTime Reca_Fecha { get; set; }

        public string Reca_Observaciones { get; set; }

        public string? Reca_Confirmacion { get; set; }

        public int? Usua_Confirmacion { get; set; }

        public bool Reca_Estado { get; set; }

        public string? Bode_Descripcion { get; set; }

        public string? Prod_DescripcionCorta { get; set; }

        public string? ReDe_Observaciones { get; set; }

        public int? ReDe_Cantidad { get; set; }


        #endregion

        #region ReporteRutas
        public int? Ruta_Id { get; set; }

        public string? Ruta_Codigo { get; set; }

        public string? Ruta_Descripcion { get; set; }

        public string? Ruta_Observaciones { get; set; }

        #endregion

        #region ReporteDevoluciones
        public int DevD_Id { get; set; }

        public int Devo_Id { get; set; }
        public int? Fact_Id { get; set; }

        public DateTime Devo_Fecha { get; set; }
        public string Devo_Motivo { get; set; }
        public string productos_Devueltos { get; set; }
        public string Nombre_Completo { get; set; }





        #endregion


    }
}
