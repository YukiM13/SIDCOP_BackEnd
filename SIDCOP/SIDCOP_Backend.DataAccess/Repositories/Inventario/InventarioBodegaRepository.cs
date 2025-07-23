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
    public class InventarioBodegaRepository : IRepository<tbInventarioBodegas>
    {
        public RequestStatus Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public tbInventarioBodegas Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbInventarioBodegas item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbInventarioBodegas> List()
        {
            throw new NotImplementedException();
        }

        public RequestStatus Update(tbInventarioBodegas item)
        {
            throw new NotImplementedException();
        }
    }
}
