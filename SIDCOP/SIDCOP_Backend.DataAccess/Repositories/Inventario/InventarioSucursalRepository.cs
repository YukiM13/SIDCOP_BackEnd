using Dapper;
using Microsoft.Data.SqlClient;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP_Backend.DataAccess.Repositories.Inventario
{
    public class InventarioSucursalRepository : IRepository<tbInventarioSucursales>
    {
        public RequestStatus Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public tbInventarioSucursales Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbInventarioSucursales item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbInventarioSucursales> List()
        {
            throw new NotImplementedException();
        }

        public RequestStatus Update(tbInventarioSucursales item)
        {
            throw new NotImplementedException();
        }
    }
}
