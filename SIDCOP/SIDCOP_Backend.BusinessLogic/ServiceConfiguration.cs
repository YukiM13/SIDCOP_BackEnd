using Microsoft.Extensions.DependencyInjection;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.DataAccess;
using SIDCOP_Backend.DataAccess.Context;
using SIDCOP_Backend.DataAccess.Repositories.Acceso;
using SIDCOP_Backend.DataAccess.Repositories.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP_Backend.BusinessLogic
{
    public static class ServiceConfiguration
    {
        public static void DataAccess(this IServiceCollection services, string connectionString)
        {
            // Initialize the connection string for repositories that use Dapper
            SIDCOP_Context.BuildConnectionString(connectionString);

            services.AddScoped<MunicipioRepository>();

            services.AddScoped<UsuarioRepository>();
            services.AddScoped<ColoniaRepository>(); 

            services.AddScoped<EstadoCivilRepository>();
        }

        public static void BusinessLogic(this IServiceCollection services)
        {
          
            services.AddScoped<GeneralServices>();
            services.AddScoped<AccesoServices>();
            //services.AddScoped<ReporteServices>();
            //services.AddScoped<DashboardServices>();
        }
    }
}
