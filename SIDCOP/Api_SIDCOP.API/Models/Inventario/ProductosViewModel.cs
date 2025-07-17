using System.ComponentModel.DataAnnotations.Schema;

namespace Api_SIDCOP.API.Models.Inventario
{
    public class ProductosViewModel
    {
        public int Prod_Id { get; set; }

        public int? Secuencia { get; set; }

        public string Prod_Codigo { get; set; }

        public string Prod_CodigoBarra { get; set; }

        public string Prod_Descripcion { get; set; }

        public string Prod_DescripcionCorta { get; set; }

        
        public int Cate_Id { get; set; }
        
        public string Cate_Descripcion { get; set; }

        public int Subc_Id { get; set; }


        public int Marc_Id { get; set; }

        public int Prov_Id { get; set; }

        public int Impu_Id { get; set; }

        public decimal? Prod_PrecioUnitario { get; set; }

        public decimal? Prod_CostoTotal { get; set; }

        public string Prod_PagaImpuesto { get; set; }

        public int? Prod_PromODesc { get; set; }

        public string Prod_EsPromo { get; set; }

        public bool Prod_Estado { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime Prod_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? Prod_FechaModificacion { get; set; }


        public string? Marc_Descripcion { get; set; }

        
        public string? Prov_NombreEmpresa { get; set; }

        
        public string? Subc_Descripcion { get; set; }

        
        public string? Impu_Descripcion { get; set; }

        
        public string? UsuarioCreacion { get; set; }

        
        public string? UsuarioModificacion { get; set; }

    }
}
