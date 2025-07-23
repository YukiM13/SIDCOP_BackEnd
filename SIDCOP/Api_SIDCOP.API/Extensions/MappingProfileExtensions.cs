using Api_SIDCOP.API.Models.Acceso;
using Api_SIDCOP.API.Models.General;
using Api_SIDCOP.API.Models.Inventario;
using Api_SIDCOP.API.Models.Logistica;
using Api_SIDCOP.API.Models.Venta;
using Api_SIDCOP.API.Models.Ventas;
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
            CreateMap<tbDepartamentos, DepartamentoViewModel>().ReverseMap();
            CreateMap<tbMarcasVehiculos, MarcaVehiculoViewModel>().ReverseMap();
            CreateMap<tbEstadosCiviles, EstadoCivilViewModel>().ReverseMap();
            // CreateMap<tbDepartamentos, DepartamentosViewModel>().ReverseMap();
            CreateMap<tbColonias, ColoniaViewModel>().ReverseMap();
            CreateMap<tbModelos, ModeloViewModel>().ReverseMap();
            CreateMap<tbCategorias, CategoriaViewModel>().ReverseMap();
            CreateMap<tbSubcategorias, SubcategoriaViewModel>().ReverseMap();
            CreateMap<tbProveedores, ProveedorViewModel>().ReverseMap();
            CreateMap<tbImpuestos, ImpuestosViewModel>().ReverseMap();
            CreateMap<tbMarcas, MarcaViewModel>().ReverseMap();
            CreateMap<tbSucursales, SucursalesViewModel>().ReverseMap();
            CreateMap<tbProductos, ProductosViewModel>().ReverseMap();
            CreateMap<tbClientes, ClienteViewModel>().ReverseMap();
            CreateMap<tbRutas, RutasViewModel>().ReverseMap();
            CreateMap<tbCAIs, CaiSViewModel>().ReverseMap();
            CreateMap<tbCanales, CanalViewModel>().ReverseMap();
            CreateMap<tbCargos, CargoViewModel>().ReverseMap();
            CreateMap<tbEmpleados, EmpleadoViewModel>().ReverseMap(); 
            CreateMap<tbRegistrosCAI, RegistrosCaiSViewModel>().ReverseMap();
            CreateMap<tbRoles, RolViewModel>().ReverseMap();
            CreateMap<tbVendedores, VendedoresViewModel>().ReverseMap();

            CreateMap<tbPermisos, PermisoViewModel>().ReverseMap();


            CreateMap<tbConfiguracionFacturas, ConfiguracionFacturaViewModel>().ReverseMap();
            CreateMap<tbBodegas, BodegaViewModel>().ReverseMap();
            CreateMap<tbPuntosEmision, PuntoEmisionViewModel>().ReverseMap();
            CreateMap<tbDireccionesPorCliente, DireccionesPorClienteViewModel>().ReverseMap();            
            CreateMap<tbDescuentos, DescuentoViewModel>().ReverseMap();
            CreateMap<tbDescuentosDetalle, DescuentoDetalleViewModel>().ReverseMap();
            CreateMap<tbDescuentoPorClientes, DescuentoPorClienteViewModel>().ReverseMap();
            CreateMap<tbDescuentosPorEscala, DescuentoPorEscalaViewModel>().ReverseMap();
            CreateMap<tbDireccionesPorCliente, DireccionesPorClienteViewModel>().ReverseMap();
            CreateMap<tbTraslados, TrasladoViewModel>().ReverseMap();

            CreateMap<tbCuentasPorCobrar, CuentasPorCobrarViewModel>().ReverseMap();
            CreateMap<tbPedidos, PedidosViewModel>().ReverseMap();


        }
    }
}
