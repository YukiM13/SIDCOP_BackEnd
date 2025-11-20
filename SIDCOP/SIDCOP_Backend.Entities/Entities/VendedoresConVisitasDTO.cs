using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP_Backend.Entities.Entities
{
    public class VendedorConVisitasDTO
    {
        public int Secuencia { get; set; }
        public int Vend_Id { get; set; }
        public string Vend_Codigo { get; set; }
        public string Vend_DNI { get; set; }
        public string Vend_Nombres { get; set; }
        public string Vend_Apellidos { get; set; }
        public string Vend_Telefono { get; set; }
        public string Vend_Correo { get; set; }
        public string Vend_Sexo { get; set; }
        public string Vend_DireccionExacta { get; set; }
        public int Sucu_Id { get; set; }
        public string Sucu_Descripcion { get; set; }
        public string Sucu_DireccionExacta { get; set; }
        public int Colo_Id { get; set; }
        public string Colo_Descripcion { get; set; }
        public string Muni_Codigo { get; set; }
        public string Muni_Descripcion { get; set; }
        public string Depa_Codigo { get; set; }
        public string Depa_Descripcion { get; set; }
        public int Vend_Supervisor { get; set; }
        public string NombreSupervisor { get; set; }
        public string ApellidoSupervisor { get; set; }
        public int Vend_Ayudante { get; set; }
        public string NombreAyudante { get; set; }
        public string ApellidoAyudante { get; set; }
        public int TiVe_Id { get; set; }
        public bool Vend_EsExterno { get; set; }
        public int RegC_Id { get; set; }

        [NotMapped]
        public string? VeRu_Dias { get; set; }
        
        [NotMapped]
        public string? Ruta_Descripcion { get; set; }

        [NotMapped]
        public string? TiVe_TipoVendedor { get; set; }
        public string Vend_Imagen { get; set; }
        public int Usua_Creacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime Vend_FechaCreacion { get; set; }
        public int? Usua_Modificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public DateTime? Vend_FechaModificacion { get; set; }
        public string rutas { get; set; }  // ← Este es JSON en string
    }

}
