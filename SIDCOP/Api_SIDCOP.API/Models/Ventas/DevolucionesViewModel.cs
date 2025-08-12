using SIDCOP_Backend.Entities.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_SIDCOP.API.Models.Ventas
{
    public class DevolucionesViewModel
    {

        public int Devo_Id { get; set; }

        public int Clie_Id { get; set; }

        public int? Fact_Id { get; set; }

        public DateTime Devo_Fecha { get; set; }

        public string Devo_Motivo { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime Devo_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? Devo_FechaModificacion { get; set; }

        public bool Devo_Estado { get; set; }

        [NotMapped]
        public string Nombre_Completo { get; set; }

        [NotMapped]
        public string Clie_NombreNegocio { get; set; }

        [NotMapped]
        public string UsuarioCreacion { get; set; }

        [NotMapped]
        public string UsuarioModificacion { get; set; }

        public virtual tbClientes Clie { get; set; }

        public virtual tbFacturas Fact { get; set; }

        public virtual tbUsuarios Usua_CreacionNavigation { get; set; }

        public virtual tbUsuarios Usua_ModificacionNavigation { get; set; }

        public virtual ICollection<tbDevolucionesDetalle> tbDevolucionesDetalle { get; set; } = new List<tbDevolucionesDetalle>();


    }
}
