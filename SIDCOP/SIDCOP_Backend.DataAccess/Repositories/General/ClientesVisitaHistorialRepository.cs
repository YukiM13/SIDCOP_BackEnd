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

        public RequestStatus InsertVisita(VisitaClientePorVendedorDTO item)
        {

            //_bddContext.tbClientesVisita.Add(item);
            //_bddContext.SaveChanges();

            if (item == null)
            {
                return new RequestStatus { code_Status = 0, message_Status = "Los datos llegaron vacios o datos erroneos" };
            }
            var parameter = new DynamicParameters();
            parameter.Add("@VeRu_Id", item.VeRu_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@DiCl_Id", item.DiCl_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@EsVi_Id", item.EsVi_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@ClVi_Observaciones", item.ClVi_Observaciones, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@ClVi_Fecha", item.ClVi_Fecha, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@ClVi_FechaCreacion", item.ClVi_FechaCreacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            try
            {
                using var db = new SqlConnection(SIDCOP_Context.ConnectionString);
                var result = db.QueryFirstOrDefault<RequestStatus>(ScriptDatabase.ClientesVisitas_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);
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

            var visitasClientes = (from cv in _bddContext.tbClientesVisita
                                            where cv.VeRu_Id.HasValue && cv.DiCl_Id.HasValue && cv.EsVi_Id.HasValue && cv.Usua_Creacion.HasValue
                                            select new
                                            {
                                                cv.ClVi_Id,
                                                VeRu_Id = cv.VeRu_Id.Value,
                                                DiCl_Id = cv.DiCl_Id.Value,
                                                EsVi_Id = cv.EsVi_Id.Value,
                                                cv.ClVi_Observaciones,
                                                cv.ClVi_Fecha,
                                                Usua_Creacion = cv.Usua_Creacion.Value,
                                                cv.ClVi_FechaCreacion,
                                            }).ToList();

            IEnumerable<VisitaClientePorVendedorDTO> clientesVisitasPorVendedor = (from cv in visitasClientes
                                                                        join rv in rutasPorVendedor on cv.VeRu_Id equals rv.VeRu_Id
                                                                        join v in _bddContext.tbVendedores on rv.Vend_Id equals v.Vend_Id
                                                                        join dc in _bddContext.tbDireccionesPorCliente on cv.DiCl_Id equals dc.DiCl_Id
                                                                        join c in _bddContext.tbClientes on dc.Clie_Id equals c.Clie_Id
                                                                        join r in _bddContext.tbRutas on rv.Ruta_Id equals r.Ruta_Id
                                                                        join esv in _bddContext.tbEstadosVisita on cv.EsVi_Id equals esv.EsVi_Id                                                                   select new VisitaClientePorVendedorDTO
                                                                        {
                                                                            ClVi_Id = cv.ClVi_Id,
                                                                            Vend_Id = v.Vend_Id,
                                                                            Vend_Codigo = v.Vend_Codigo,
                                                                            Vend_Nombres = v.Vend_Nombres,
                                                                            Vend_Apellidos = v.Vend_Apellidos,
                                                                            Vend_Tipo = v.Vend_Tipo,
                                                                            Vend_Telefono = v.Vend_Telefono,
                                                                            Ruta_Id = rv.Ruta_Id,
                                                                            Ruta_Descripcion = r.Ruta_Descripcion,
                                                                            VeRu_Id = cv.VeRu_Id,
                                                                            VeRu_Dias = rv.VeRu_Dias,
                                                                            Clie_Id = dc.Clie_Id,
                                                                            Clie_Codigo = c.Clie_Codigo,
                                                                            Clie_Nombres = c.Clie_Nombres,
                                                                            Clie_Apellidos = c.Clie_Apellidos,
                                                                            Clie_NombreNegocio = c.Clie_NombreNegocio,
                                                                            ClVi_Fecha = cv.ClVi_Fecha,
                                                                            ClVi_Observaciones = cv.ClVi_Observaciones,
                                                                            EsVi_Id = cv.EsVi_Id,
                                                                            EsVi_Descripcion = esv.EsVi_Descripcion,
                                                                            DiCl_Id = dc.DiCl_Id,
                                                                            DiCl_Latitud = dc.DiCl_Latitud,
                                                                            DiCl_Longitud = dc.DiCl_Longitud,
                                                                            Usua_Creacion = cv.Usua_Creacion,
                                                                            ClVi_FechaCreacion = (DateTime)cv.ClVi_FechaCreacion,
                                                                        });

            return clientesVisitasPorVendedor.ToList();
        }

        public RequestStatus Update(tbClientesVisita item)
        {
            //var entity = _bddContext.tbClientesVisita.Find(item.HCVi_Id);
            //entity.HCVi_Latitud = item.HCVi_Latitud;
            //entity.HCVi_Longitud = item.HCVi_Longitud;
            //_bddContext.SaveChanges();
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbClientesVisita item)
        {
            throw new NotImplementedException();
        }
    }
}
