using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP_Backend.DataAccess
{
    public class RequestStatus
    {
        internal int codeStatus;

        public int code_Status { get; set; }
        public string message_Status { get; set; }

        public string data { get; set; }

        public int? Tras_Id { get; set; }
    }

}
