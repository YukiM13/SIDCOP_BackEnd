using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Sistema_Reportes.API.Helpers
{
    public class ApiKeyValidator : IApiKeyValidator
    {
        private readonly string? _configuredApiKey;

        public ApiKeyValidator(IConfiguration configuration)
        {
            _configuredApiKey = configuration.GetValue<string>("ApiKey");
        }

        public bool IsValid(string apikey)
        {
            // todo, improve this
            return apikey == _configuredApiKey;
        }
    }
}