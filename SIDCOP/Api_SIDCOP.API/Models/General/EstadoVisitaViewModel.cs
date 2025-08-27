using SIDCOP_Backend.Entities.Entities;

namespace Api_SIDCOP.API.Models.General
{
    public class EstadoVisitaViewModel
    {

        public int? EsVi_Id { get; set; }

        public string? EsVi_Descripcion { get; set; }

        public int? Usua_Creacion { get; set; }

        public DateTime? EsVi_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? EsVi_FechaModificacion { get; set; }

        public int? Secuencia { get; set; }

        public string? UsuarioCreacion { get; set; }

        public string? UsuarioModificacion { get; set; }


    }
}
