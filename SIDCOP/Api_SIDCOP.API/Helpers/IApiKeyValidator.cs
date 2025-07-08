using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Sistema_Reportes.API.Helpers
{
    public interface IApiKeyValidator
    {
        public bool IsValid(string apikey);
    }
}