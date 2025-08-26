using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;

namespace SIDCOP_Backend.DataAccess
{
    public class DbContextFactory
    {
        private readonly IConfiguration _config;
        private string _lastConnectionString;
        private DateTime _lastCheck = DateTime.MinValue;
        private readonly TimeSpan _cacheTime = TimeSpan.FromSeconds(5); // Cache por 5 segundos para evitar sobrecarga

        public DbContextFactory(IConfiguration config)
        {
            _config = config;
            _lastConnectionString = GetBestConnectionString();
        }

        public string GetConnectionString()
        {
            // Si ha pasado el tiempo de caché, verificar de nuevo
            if (DateTime.Now - _lastCheck > _cacheTime)
            {
                _lastConnectionString = GetBestConnectionString();
                _lastCheck = DateTime.Now;
            }
            
            return _lastConnectionString;
        }

        private string GetBestConnectionString()
        {
            var connLocal = _config.GetConnectionString("SIDCOPConn_Local");
            var connRemoto = _config.GetConnectionString("SIDCOPConn_Remoto");

            try
            {
                using (var conn = new SqlConnection(connLocal))
                {
                    // Establecer un timeout corto para la prueba
                    conn.ConnectionString += ";Connection Timeout=2";
                    conn.Open();
                    Console.WriteLine($"[{DateTime.Now}] Usando conexión LOCAL");
                    return connLocal;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[{DateTime.Now}] Conexión local fallida: {ex.Message}");
                Console.WriteLine($"[{DateTime.Now}] Usando conexión REMOTA");
                return connRemoto;
            }
        }
    }
}
