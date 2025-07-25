using System.ComponentModel.DataAnnotations.Schema;

namespace Api_SIDCOP.API.Models.Inventario
{
    public class DescuentoViewModel
    {
        public int Desc_Id { get; set; }

        public string Desc_Descripcion { get; set; }

        public bool Desc_Tipo { get; set; }

        public string Desc_Aplicar { get; set; }

        public DateTime Desc_FechaInicio { get; set; }

        public DateTime Desc_FechaFin { get; set; }

        public string Desc_Observaciones { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime Desc_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? Desc_FechaModificacion { get; set; }

        public bool Desc_Estado { get; set; }

        public string? clientes { get; set; }

        public string? referencias { get; set; }
        public string? escalas { get; set; }
        public List<int>? IdClientes { get; set; }

        public List<int>? IdReferencias { get; set; }

        public int? Secuencia { get; set; }

        public string? UsuarioCreacion { get; set; }
        public string? UsuarioModificacion { get; set; }



        public List<EscalaDetalleViewModel> escalas_Json { get; set; }
    }

   
}
