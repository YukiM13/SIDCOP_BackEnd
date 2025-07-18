using System.ComponentModel.DataAnnotations.Schema;

namespace Api_SIDCOP.API.Models.Acceso
{
    public class PermisoViewModel
    {
        public int Perm_Id { get; set; }

        public int AcPa_Id { get; set; }

        public int Role_Id { get; set; }

        
        public string Role_Descripcion { get; set; }

        
        public int Pant_Id { get; set; }

        
        public string Pant_Descripcion { get; set; }

        
        public int Acci_Id { get; set; }

        
        public string Acci_Descripcion { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime Perm_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? Perm_FechaModificacion { get; set; }
    }
}
