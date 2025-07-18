using System.ComponentModel.DataAnnotations.Schema;

namespace Api_SIDCOP.API.Models.Acceso
{
    public class UsuarioViewModel
    {
        public int Usua_Id { get; set; }

        public string Usua_Usuario { get; set; }

        [NotMapped]
        public string? Correo { get; set; }


        public string Usua_Clave { get; set; }

        public int Role_Id { get; set; }

        public int Usua_IdPersona { get; set; }

        public bool Usua_EsVendedor { get; set; }

        public bool Usua_EsAdmin { get; set; }

        public string? Usua_Imagen { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime Usua_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? Usua_FechaModificacion { get; set; }

        public bool Usua_Estado { get; set; }

        public string? PermisosJson { get; set; }



    }
}