using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP_Backend.Entities.Entities
{
    public class ReporteCuentasPorCobrar
    {
        public int Clie_Id { get; set; }
        public string Cliente { get; set; }
        public string Clie_NombreNegocio { get; set; }
        public int Fact_Id { get; set; }
        public string Fact_Numero { get; set; }
        public int CPCo_Id { get; set; }
        public DateTime CPCo_FechaEmision { get; set; }
        public DateTime CPCo_FechaVencimiento { get; set; }
        public decimal CPCo_Valor { get; set; }
        public decimal CPCo_Saldo { get; set; }
        public string Anulada { get; set; }
        public string Saldada { get; set; }
        public DateTime Pago_Fecha { get; set; }
        public decimal Pago_Monto { get; set; }
        public string Pago_FormaPago { get; set; }
        public string Pago_Observaciones { get; set; }
        public string Anulado { get; set; }
    }
}