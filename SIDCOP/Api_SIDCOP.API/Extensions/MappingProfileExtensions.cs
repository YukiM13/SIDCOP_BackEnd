using Api_SIDCOP.API.Models.Acceso;
using Api_SIDCOP.API.Models.General;
using Api_SIDCOP.API.Models.Inventario;
using AutoMapper;
using SIDCOP_Backend.Entities.Entities;




namespace Api_SIDCOP.API.Extensions
{
    public class MappingProfileExtensions: Profile
    {
        public MappingProfileExtensions()
        {
            CreateMap<tbUsuarios, UsuarioViewModel>().ReverseMap();
            CreateMap<tbEstadosCiviles, EstadoCivilViewModel>().ReverseMap();
            // CreateMap<tbDepartamentos, DepartamentosViewModel>().ReverseMap();
            CreateMap<tbColonias, ColoniaViewModel>().ReverseMap();
            CreateMap<tbModelos, ModeloViewModel>().ReverseMap();
            CreateMap<tbCategorias, CategoriaViewModel>().ReverseMap();
            CreateMap<tbSubcategorias, SubcategoriaViewModel>().ReverseMap();
            CreateMap<tbProveedores, ProveedorViewModel>().ReverseMap();
            CreateMap<tbSucursales, SucursalesViewModel>().ReverseMap();
            CreateMap<tbProductos, ProductosViewModel>().ReverseMap();

            CreateMap<tbClientes, ClienteViewModel>().ReverseMap();

        }
    }
}
