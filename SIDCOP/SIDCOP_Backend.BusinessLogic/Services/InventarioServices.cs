using SIDCOP_Backend.Entities.Entities;
using SIDCOP_Backend.DataAccess.Repositories.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDCOP_Backend.BusinessLogic.Services
{
    public class InventarioServices
    {
        private readonly CategoriasRepository _categoriasRepository;
        private readonly SubcategoriasRepository _subcategoriasRepository;

        public InventarioServices(CategoriasRepository categoriasRepository, SubcategoriasRepository subcategoriasRepository)
        {
            _categoriasRepository = categoriasRepository;
            _subcategoriasRepository = subcategoriasRepository;
        }

        #region Categorias

        public IEnumerable<tbCategorias> ListarCategorias()
        {
            try
            {
                var list = _categoriasRepository.List();
                return list;
            }
            catch (Exception)
            {
                IEnumerable<tbCategorias> categorias = null;
                return categorias;
            }
        }

        public ServiceResult InsertarCategoria(tbCategorias item)
        {
            var result = new ServiceResult();
            try
            {
                var resultado = _categoriasRepository.Insert(item);
                return result.Ok(resultado);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ActualizarCategoria(tbCategorias item)
        {
            var result = new ServiceResult();
            try
            {
                var resultado = _categoriasRepository.Update(item);
                return result.Ok(resultado);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult EliminarCategoria(tbCategorias item)
        {
            var result = new ServiceResult();
            try
            {
                var resultado = _categoriasRepository.Delete(item);
                return result.Ok(resultado);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult BuscarCategoria(tbCategorias item)
        {
            var result = new ServiceResult();
            try
            {
                var resultado = _categoriasRepository.FindCodigo(item);
                return result.Ok(resultado);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        #endregion

        #region Subcategorias
        public IEnumerable<tbSubcategorias> ListarSubCategorias()
        {
            try
            {
                var list = _subcategoriasRepository.List();
                return list;
            }
            catch (Exception)
            {
                IEnumerable<tbSubcategorias> subcategorias = null;
                return subcategorias;
            }
        }

        public ServiceResult InsertarSubCategoria(tbSubcategorias item)
        {
            var result = new ServiceResult();
            try
            {
                var resultado = _subcategoriasRepository.Insert(item);
                return result.Ok(resultado);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ActualizarSubCategoria(tbSubcategorias item)
        {
            var result = new ServiceResult();
            try
            {
                var resultado = _subcategoriasRepository.Update(item);
                return result.Ok(resultado);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult EliminarSubCategoria(tbSubcategorias item)
        {
            var result = new ServiceResult();
            try
            {
                var resultado = _subcategoriasRepository.Delete(item);
                return result.Ok(resultado);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult BuscarSubCategoria(tbSubcategorias item)
        {
            var result = new ServiceResult();
            try
            {
                var resultado = _subcategoriasRepository.FindCodigo(item);
                return result.Ok(resultado);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        #endregion
    }
}
