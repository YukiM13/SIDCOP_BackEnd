using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIDCOP_Backend.DataAccess.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace SIDCOP_Backend.DataAccess
{
    public class SIDCOP_Context : BDD_SIDCOPContext
    {
        private static string _connectionString;
        private static DbContextFactory _factory;
        
        public static string ConnectionString 
        { 
            get 
            { 
                // Si tenemos un factory, usarlo para obtener la cadena de conexión
                if (_factory != null)
                {
                    return _factory.GetConnectionString();
                }
                // Si no hay factory, usar la cadena estática
                return _connectionString; 
            }
            set { _connectionString = value; } 
        }

        public SIDCOP_Context()
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Usar la propiedad ConnectionString que ya maneja la lógica de obtener la mejor conexión
                optionsBuilder.UseSqlServer(ConnectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }
        public static void BuildConnectionString(string connection)
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder { ConnectionString = connection };
            _connectionString = connectionStringBuilder.ConnectionString;
        }
        
        public static void SetFactory(DbContextFactory factory)
        {
            _factory = factory;
        }
        
    }
}
