namespace Api_SIDCOP.API.Models.Inventario
{
    public class HistorialInventarioSucursalViewModel
    {
        public int HISu_Id { get; set; }

        public int? InSu_Id { get; set; }

        public int? Sucu_Id { get; set; }

        public int? Prod_Id { get; set; }

        public int? InSu_Cantidad { get; set; }

        public int? InSu_NuevaCantidad { get; set; }
        public bool? InSu_Estado { get; set; }

        public string HISu_Accion { get; set; }

        public DateTime HISu_FechaAccion { get; set; }

        public int HISu_UsuarioAccion { get; set; }

        public string Usua_Usuario { get; set; }
        public string Prod_DescripcionCorta { get; set; }
    }
}
