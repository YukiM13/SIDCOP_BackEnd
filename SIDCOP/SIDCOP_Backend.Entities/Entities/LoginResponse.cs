using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP_Backend.Entities.Entities
{
    public class LoginResponse
    {
        public int code_Status { get; set; }
        public string? message_Status { get; set; }

        public int Usua_Id { get; set; }

        public string Usua_Usuario { get; set; }

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