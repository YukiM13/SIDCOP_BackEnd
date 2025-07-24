using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        [NotMapped]

        public string? Role_Descripcion { get; set; }

        [NotMapped]
        public string? Cargo { get; set; }

        [NotMapped]
        public string? DNI { get; set; }

        [NotMapped]
        public string? Correo { get; set; }

        [NotMapped]
        public string? Telefono { get; set; }

        public int? PersonaId { get; set; }

        [NotMapped]
        public string? Imagen { get; set; }

        [NotMapped]
        public string? Nombres { get; set; }

        [NotMapped]
        public string? Apellidos { get; set; }

        [NotMapped]
        public string? Sucursal { get; set; }

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