using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SIDCOP_Backend.DataAccess.Context;
using SIDCOP_Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP_Backend.DataAccess.Repositories.General
{
    public class ClientesVisitaHistorialRepository : IRepository<tbClientesVisita>
    {
        private readonly BDD_SIDCOPContext _bddContext;
        public ClientesVisitaHistorialRepository(BDD_SIDCOPContext bddContext)
        {
            _bddContext = bddContext;
        }

        public RequestStatus Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public tbClientesVisita Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbClientesVisita item)
        {

            _bddContext.tbClientesVisita.Add(item);
            _bddContext.SaveChanges();


            if (item == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "Los datos llegaron vacios o datos erroneos" };
            }
            var parameter = new DynamicParameters();
            parameter.Add("@VeRu_Id", item.VeRu_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            //parameter.Add("@Clie_Id", item.Clie_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            //parameter.Add("@HCVi_Foto", item.HCVi_Foto, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            //parameter.Add("@HCVi_Observaciones", item.HCVi_Observaciones, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            //parameter.Add("@HCVi_Fecha", item.HCVi_Fecha, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);
            //parameter.Add("@HCVi_Latitud", item.HCVi_Latitud, System.Data.DbType.Decimal, System.Data.ParameterDirection.Input);
            //parameter.Add("@HCVi_Longitud", item.HCVi_Longitud, System.Data.DbType.Decimal, System.Data.ParameterDirection.Input);
            //parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            //parameter.Add("@HCVi_FechaCreacion", item.HCVi_FechaCreacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.ClientesVisitasHistorial_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);
                if (result == null)
                {
                    return new RequestStatus { code_Status = 0, message_Status = "Error Desconocido" };
                }
                return result;
            }
            catch (Exception ex)
            {
                return new RequestStatus { code_Status = 0, message_Status = $"Error inesperado: {ex.Message}" };
            }

        }

        public IEnumerable<tbClientesVisita> List()
        {

            IEnumerable<tbClientesVisita> clientesVisitaHistorial = (from v in _bddContext.tbClientesVisita
                                                                              select new tbClientesVisita
                                                                              {
                                                                                  //HCVi_Id = v.HCVi_Id,
                                                                                  //VeRu_Id = v.VeRu_Id,
                                                                                  //Clie_Id = v.Clie_Id,
                                                                                  //HCVi_Foto = v.HCVi_Foto,
                                                                                  //HCVi_Observaciones = v.HCVi_Observaciones,
                                                                                  //HCVi_Fecha = v.HCVi_Fecha,
                                                                                  //HCVi_Latitud = v.HCVi_Latitud,
                                                                                  //HCVi_Longitud = v.HCVi_Longitud
                                                                              });

            //var parameter = new DynamicParameters();

            //using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            //var result = db.Query<tbClientesVisita>(ScriptDatabase.ClientesVisitasHistorial_Listar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            return clientesVisitaHistorial;
        }

        public tbClientesVisita FindByVendedor(int? id)
        {
            using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
            var parameter = new DynamicParameters();
            parameter.Add("@Vend_Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            var result = db.QueryFirstOrDefault<tbClientesVisita>(ScriptDatabase.VisitasPorVendedor_Listar, parameter, commandType: System.Data.CommandType.StoredProcedure);
            if (result == null)
            {
                throw new Exception("Cliente no encontrado");
            }
            return result;
        }

        public IEnumerable<VisitaClientePorVendedorDTO> VisitasPorVendedor(int vend_Id)
        {
            List<tbVendedoresPorRuta> rutasPorVendedor = _bddContext.tbVendedoresPorRuta.AsNoTracking().Where(vpr => vpr.Vend_Id == vend_Id).ToList();

            //var historialClientesVisitas = (from cv in _bddContext.tbClientesVisita
            //                                where cv.VeRu_Id.HasValue && cv.Clie_Id.HasValue
            //                                select new
            //                                {
            //                                    cv.HCVi_Id,
            //                                    VeRu_Id = cv.VeRu_Id.Value,
            //                                    Clie_Id = cv.Clie_Id.Value,
            //                                    cv.HCVi_Foto,
            //                                    cv.HCVi_Observaciones,
            //                                    cv.HCVi_Fecha,
            //                                    cv.HCVi_Latitud,
            //                                    cv.HCVi_Longitud,
            //                                    cv.Usua_Creacion,
            //                                    cv.HCVi_FechaCreacion,
            //                                }).ToList();

            //IEnumerable<VisitaClientePorVendedorDTO> clientesVisitas = (from cv in historialClientesVisitas
            //                                                     join rv in rutasPorVendedor on cv.VeRu_Id equals rv.VeRu_Id
            //                                                     join v in _bddContext.tbVendedores on rv.Vend_Id equals v.Vend_Id
            //                                                     join c in _bddContext.tbClientes on cv.Clie_Id equals c.Clie_Id
            //                                                     join r in _bddContext.tbRutas on rv.Ruta_Id equals r.Ruta_Id
            //                                                     select new VisitaClientePorVendedorDTO
            //                                                     {
            //                                                         HCVi_Id = cv.HCVi_Id,
            //                                                         VeRu_Id = cv.VeRu_Id,
            //                                                         Vend_Id = v.Vend_Id,
            //                                                         Vend_Codigo = v.Vend_Codigo,
            //                                                         Vend_Nombres = v.Vend_Nombres,
            //                                                         Vend_Apellidos = v.Vend_Apellidos,
            //                                                         Vend_Tipo = v.Vend_Tipo,
            //                                                         Vend_Telefono = v.Vend_Telefono,
            //                                                         VeRu_Dias = rv.VeRu_Dias,
            //                                                         Ruta_Id = r.Ruta_Id,
            //                                                         Ruta_Descripcion = r.Ruta_Descripcion,
            //                                                         Clie_Id = cv.Clie_Id,
            //                                                         Clie_Codigo = c.Clie_Codigo,
            //                                                         Clie_Nombres = c.Clie_Nombres,
            //                                                         Clie_Apellidos = c.Clie_Apellidos,
            //                                                         Clie_NombreNegocio = c.Clie_NombreNegocio,
            //                                                         HCVi_Foto = cv.HCVi_Foto,
            //                                                         HCVi_Observaciones = cv.HCVi_Observaciones,
            //                                                         HCVi_Fecha = cv.HCVi_Fecha,
            //                                                         HCVi_Latitud = cv.HCVi_Latitud,
            //                                                         HCVi_Longitud = cv.HCVi_Longitud,
            //                                                         Usua_Creacion = cv.Usua_Creacion,
            //                                                         HCVi_FechaCreacion = cv.HCVi_FechaCreacion,
            //                                                     });

            return null;
        }

        public RequestStatus Update(tbClientesVisita item)
        {
            //var entity = _bddContext.tbClientesVisita.Find(item.HCVi_Id);
            //entity.HCVi_Latitud = item.HCVi_Latitud;
            //entity.HCVi_Longitud = item.HCVi_Longitud;
            //_bddContext.SaveChanges();
            throw new NotImplementedException();
        }
    }
}
