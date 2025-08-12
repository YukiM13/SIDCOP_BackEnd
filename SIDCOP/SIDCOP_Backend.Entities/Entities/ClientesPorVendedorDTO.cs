using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP_Backend.Entities.Entities
{
    public class ClientesPorVendedorDTO
    {
        public string Vendedor { get; set; }
        public string VeRu_Dias { get; set; }
        public int Ruta_Id { get; set; }
        public string Ruta_Descripcion { get; set; }

        public string Cliente { get; set; }

        public string Clie_NombreNegocio { get; set; }
    }
}
