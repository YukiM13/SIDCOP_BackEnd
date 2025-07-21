using SIDCOP_Backend.Entities.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_SIDCOP.API.Models.Ventas
{
    public class RegistrosCaiSViewModel
    {
        public int RegC_Id { get; set; }

        public string RegC_Descripcion { get; set; }

        public int? Sucu_Id { get; set; }

        public int? PuEm_Id { get; set; }

        public int NCai_Id { get; set; }

        public string RegC_RangoInicial { get; set; }

        public string RegC_RangoFinal { get; set; }

        public DateTime RegC_FechaInicialEmision { get; set; }

        public DateTime RegC_FechaFinalEmision { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime RegC_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? RegC_FechaModificacion { get; set; }

        public bool RegC_Estado { get; set; }

        
        public int Secuencia { get; set; }

        
        public String Estado { get; set; }

        
        public String UsuarioCreacion { get; set; }

        
        public String UsuarioModificacion { get; set; }

        
        public String Sucu_Descripcion { get; set; }

        
        public String PuEm_Descripcion { get; set; }

        
        public String NCai_Descripcion { get; set; }

        //public virtual tbCAIs NCai { get; set; }

        //public virtual tbPuntosEmision PuEm { get; set; }

        //public virtual tbSucursales Sucu { get; set; }

        //public virtual tbUsuarios Usua_CreacionNavigation { get; set; }

        //public virtual tbUsuarios Usua_ModificacionNavigation { get; set; }
    }
}
