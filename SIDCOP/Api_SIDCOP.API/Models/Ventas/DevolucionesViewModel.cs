using SIDCOP_Backend.Entities.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_SIDCOP.API.Models.Ventas
{
    public class DevolucionesViewModel
    {

        public int Devo_Id { get; set; }

        public int? Fact_Id { get; set; }

        public DateTime Devo_Fecha { get; set; }

        public string Devo_Motivo { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime Devo_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? Devo_FechaModificacion { get; set; }

        public bool Devo_Estado { get; set; }

        public bool Devo_EnSucursal { get; set; }

        public string Nombre_Completo { get; set; }


        public string Clie_NombreNegocio { get; set; }


        public string UsuarioCreacion { get; set; }

        public string UsuarioModificacion { get; set; }

        public string devoDetalle_XML { get; set; }



    }
}
