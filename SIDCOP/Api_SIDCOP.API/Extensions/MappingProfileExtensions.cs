using Api_SIDCOP.API.Models.Acceso;
using Api_SIDCOP.API.Models.General;
using AutoMapper;
using SIDCOP_Backend.Entities.Entities;




namespace Api_SIDCOP.API.Extensions
{
    public class MappingProfileExtensions: Profile
    {
        public MappingProfileExtensions()
        {
            CreateMap<tbUsuarios, UsuarioViewModel>().ReverseMap();

            CreateMap<tbMunicipios, MunicipioViewModel>().ReverseMap();
            CreateMap<tbEstadosCiviles, EstadoCivilViewModel>().ReverseMap();
            // CreateMap<tbDepartamentos, DepartamentosViewModel>().ReverseMap();
            CreateMap<tbColonias, ColoniaViewModel>().ReverseMap();

        }
    }
}
