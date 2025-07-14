using SIDCOP_Backend.Entities.Entities;

namespace Api_SIDCOP.API.Models.Acceso
{
    public class RolViewModel
    {
        public int Role_Id { get; set; }

        public string Role_Descripcion { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime Role_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? Role_FechaModificacion { get; set; }

        public bool Role_Estado { get; set; }
    }
}
