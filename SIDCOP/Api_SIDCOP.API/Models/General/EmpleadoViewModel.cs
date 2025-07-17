using System.ComponentModel.DataAnnotations.Schema;

namespace Api_SIDCOP.API.Models.General
{
    public class EmpleadoViewModel
    {

        public int Empl_Id { get; set; }

        public string Empl_DNI { get; set; }

        public string Empl_Codigo { get; set; }

        public string Empl_Nombres { get; set; }

        public string Empl_Apellidos { get; set; }

        public string Empl_Sexo { get; set; }

        public DateTime Empl_FechaNacimiento { get; set; }

        public string Empl_Correo { get; set; }

        public string Empl_Telefono { get; set; }

        public int Sucu_Id { get; set; }

        public int EsCv_Id { get; set; }

        public int Carg_Id { get; set; }

        public int Colo_Id { get; set; }

        public string Empl_DireccionExacta { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime Empl_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? Empl_FechaModificacion { get; set; }

        public bool Empl_Estado { get; set; }

        
        public string? Sucu_Descripcion { get; set; }

        
        public string? EsCv_Descripcion { get; set; }

        
        public string? Carg_Descripcion { get; set; }

        
        public string? Colo_Descripcion { get; set; }

        
        public string? UsuarioCreacion { get; set; }

        
        public string? UsuarioModificacion { get; set; }

        
        public string? Usua_Imagen { get; set; }
    }
}
