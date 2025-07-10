using Api_SIDCOP.API.Models.Acceso;
using Api_SIDCOP.API.Models.General;
using Api_SIDCOP.API.Models.Venta;
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



            CreateMap<tbConfiguracionFacturas, ConfiguracionFacturaViewModel>().ReverseMap();

        }
    }
}
