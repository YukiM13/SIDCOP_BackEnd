using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP_Backend.Entities.Entities
{
    public class ReporteProductosVendidosRuta
    {
        public int Vend_Id { get; set; }
        public int Secuencia { get; set; }
        public string Vend_DNI { get; set; }
        public string NombreCompleto { get; set; }
        public int Ruta_Id { get; set; }
        public string Ruta_Descripcion { get; set; }
        public int Prod_Id { get; set; }
        public string Prod_DescripcionCorta { get; set; }
        public int CantidadVendida { get; set; }
    }
}
