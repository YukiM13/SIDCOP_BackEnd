using Microsoft.Extensions.DependencyInjection;
using SIDCOP_Backend.BusinessLogic.Services;
using SIDCOP_Backend.DataAccess;
using SIDCOP_Backend.DataAccess.Context;
using SIDCOP_Backend.DataAccess.Repositories.Acceso;
using SIDCOP_Backend.DataAccess.Repositories.General;
using SIDCOP_Backend.DataAccess.Repositories.Inventario;
using SIDCOP_Backend.DataAccess.Repositories.Logistica;
using SIDCOP_Backend.DataAccess.Repositories.Ventas;
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

            services.AddScoped<UsuarioRepository>();
            services.AddScoped<DepartamentoRepository>();
            services.AddScoped<MarcaVehiculoRepository>();

            services.AddScoped<ColoniaRepository>();
            services.AddScoped<MarcaRepository>();

            services.AddScoped<SucursalesRepository>();

            services.AddScoped<ColoniaRepository>(); 

            services.AddScoped<EstadoCivilRepository>();
            services.AddScoped<ProductosRepository>();

            services.AddScoped<ClienteRepository>();

            services.AddScoped<RutasRepository>();
            services.AddScoped<CaiSRepository>();

            services.AddScoped<CanalRepository>();
            services.AddScoped<EmpleadoRepository>();
            services.AddScoped<RegistrosCaiSRepository>();

            services.AddScoped<RolRepository>();
        }

        public static void BusinessLogic(this IServiceCollection services)
        {

            services.AddScoped<GeneralServices>();
            services.AddScoped<AccesoServices>();
            services.AddScoped<InventarioServices>();
            services.AddScoped<VentaServices>();
            services.AddScoped<LogisticaServices>();
            services.AddScoped<RolRepository>();
            //services.AddScoped<ReporteServices>();
            //services.AddScoped<DashboardServices>();
        }
    }
}
