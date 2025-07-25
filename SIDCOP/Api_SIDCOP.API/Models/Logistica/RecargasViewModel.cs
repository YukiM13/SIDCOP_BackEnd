using SIDCOP_Backend.Entities.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_SIDCOP.API.Models.Logistica
{
    public class RecargasViewModel
    {
        public int Reca_Id { get; set; }

        public int Vend_Id { get; set; }

        public int Bode_Id { get; set; }

        public int? Tras_Id { get; set; }

        public DateTime Reca_Fecha { get; set; }

        public string Reca_Observaciones { get; set; }

        public bool Reca_Confirmacion { get; set; }

        public int? Usua_Confirmacion { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime Reca_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? Reca_FechaModificacion { get; set; }

        public bool Reca_Estado { get; set; }

        public string? Bode_Descripcion { get; set; }

        public string? Prod_DescripcionCorta { get; set; }

        public string? Prod_Codigo { get; set; }

        public string? Prod_Imagen { get; set; }

        public string? ReDe_Observaciones { get; set; }

        public int? ReDe_Cantidad { get; set; }

        public List<RecargaDetalleDTO> Detalles { get; set; }
    }
}
