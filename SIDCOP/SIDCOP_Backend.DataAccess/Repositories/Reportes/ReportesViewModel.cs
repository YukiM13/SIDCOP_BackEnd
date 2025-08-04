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


    }
}
