using SIDCOP_Backend.Entities.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_SIDCOP.API.Models.Ventas
{
    public class PedidosViewModel
    {

        public int? Secuencia { get; set; }

        public string Pedi_Codigo { get; set; }

        public int Pedi_Id { get; set; }

        public int DiCl_Id { get; set; }

        public int Vend_Id { get; set; }

        public DateTime Pedi_FechaPedido { get; set; }

        public DateTime? Pedi_FechaEntrega { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime Pedi_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? Pedi_FechaModificacion { get; set; }

        public bool Pedi_Estado { get; set; }


        public string? Clie_Codigo { get; set; }

      
        public int? Clie_Id { get; set; }


        public string? Clie_NombreNegocio { get; set; }


        public string? Clie_Nombres { get; set; }


        public string? Clie_Apellidos { get; set; }


        public string? Colo_Descripcion { get; set; }


        public string? Muni_Descripcion { get; set; }


        public string? Depa_Descripcion { get; set; }


        public string? DiCl_DireccionExacta { get; set; }



        public string? Vend_Nombres { get; set; }


        public string? Vend_Apellidos { get; set; }


        public string? UsuarioCreacion { get; set; }


        public string? UsuarioModificacion { get; set; }


        public string? Prod_Codigo { get; set; }


        public string? Prod_Descripcion { get; set; }


        public decimal? PeDe_ProdPrecio { get; set; }


        public int? PeDe_Cantidad { get; set; }
        public List<PedidoDetalleDTO> Detalles { get; set; }

        public string? DetallesJson { get; set; }

    }
}
