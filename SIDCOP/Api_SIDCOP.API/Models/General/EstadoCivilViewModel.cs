using SIDCOP_Backend.Entities.Entities;

namespace Api_SIDCOP.API.Models.General
{
    public class EstadoCivilViewModel
    {
        public int EsCv_Id { get; set; }

        public string EsCv_Descripcion { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime EsCv_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? EsCv_FechaModificacion { get; set; }

 
    }

}

