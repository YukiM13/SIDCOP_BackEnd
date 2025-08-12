using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP_Backend.Entities.Entities
{
    public class ClienteCambiarEstadoDTO
    {
        public int Clie_Id { get; set; }
        public DateTime FechaActual { get; set; }

        public int code_Status { get; set; }
        public string? message_Status { get; set; }
    }

}
