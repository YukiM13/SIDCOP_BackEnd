using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP_Backend.Entities.Entities
{
    public class DashboardMarcasMasVendidas
    {
        public int Marc_Id { get; set; }
        public string Marc_Descripcion { get; set; }
        public int CantidadVendida { get; set; }
        public int Prod_Id { get; set; }
        public string Prod_Descripcion { get; set; }
    }
}
