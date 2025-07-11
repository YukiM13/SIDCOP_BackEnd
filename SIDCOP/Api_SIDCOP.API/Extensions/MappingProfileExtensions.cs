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
            CreateMap<tbDepartamentos, DepartamentoViewModel>().ReverseMap();
            CreateMap<tbMarcasVehiculos, MarcaVehiculoViewModel>().ReverseMap();
            CreateMap<tbEstadosCiviles, EstadoCivilViewModel>().ReverseMap();
            // CreateMap<tbDepartamentos, DepartamentosViewModel>().ReverseMap();
            CreateMap<tbColonias, ColoniaViewModel>().ReverseMap();
            CreateMap<tbMarcas, MarcaViewModel>().ReverseMap();
            CreateMap<tbSucursales, SucursalesViewModel>().ReverseMap();
            CreateMap<tbProductos, ProductosViewModel>().ReverseMap();

            CreateMap<tbClientes, ClienteViewModel>().ReverseMap();
            CreateMap<tbCanales, CanalViewModel>().ReverseMap();
            CreateMap<tbCargos, CargoViewModel>().ReverseMap();
            CreateMap<tbEmpleados, EmpleadoViewModel>().ReverseMap(); 

        }
    }
}
