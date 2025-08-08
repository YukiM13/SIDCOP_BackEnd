using System.ComponentModel.DataAnnotations;

namespace Api_SIDCOP.API.Models.Ventas
{
    public class VentaInsertarViewModel
    {
        [Required(ErrorMessage = "El número de factura es requerido")]
        [StringLength(20, ErrorMessage = "El número de factura no puede exceder 20 caracteres")]
        public string Fact_Numero { get; set; }

        [Required(ErrorMessage = "El tipo de documento es requerido")]
        [StringLength(3, ErrorMessage = "El tipo de documento no puede exceder 3 caracteres")]
        public string Fact_TipoDeDocumento { get; set; }

        [Required(ErrorMessage = "El ID del registro CAI es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID del registro CAI debe ser mayor a 0")]
        public int RegC_Id { get; set; }

        [Required(ErrorMessage = "El ID del cliente es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID del cliente debe ser mayor a 0")]
        public int Clie_Id { get; set; }

        [Required(ErrorMessage = "El ID del vendedor es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID del vendedor debe ser mayor a 0")]
        public int Vend_Id { get; set; }

        [Required(ErrorMessage = "El tipo de venta es requerido")]
        [RegularExpression("^(CONTADO|CREDITO)$", ErrorMessage = "El tipo de venta debe ser CONTADO o CREDITO")]
        public string Fact_TipoVenta { get; set; }

        [Required(ErrorMessage = "La fecha de emisión es requerida")]
        public DateTime Fact_FechaEmision { get; set; }

        [Required(ErrorMessage = "La fecha límite de emisión es requerida")]
        public DateTime Fact_FechaLimiteEmision { get; set; }

        [Required(ErrorMessage = "El rango inicial autorizado es requerido")]
        [StringLength(20, ErrorMessage = "El rango inicial no puede exceder 20 caracteres")]
        public string Fact_RangoInicialAutorizado { get; set; }

        [Required(ErrorMessage = "El rango final autorizado es requerido")]
        [StringLength(20, ErrorMessage = "El rango final no puede exceder 20 caracteres")]
        public string Fact_RangoFinalAutorizado { get; set; }

        [Required(ErrorMessage = "La latitud es requerida")]
        [Range(-90, 90, ErrorMessage = "La latitud debe estar entre -90 y 90 grados")]
        public decimal Fact_Latitud { get; set; }

        [Required(ErrorMessage = "La longitud es requerida")]
        [Range(-180, 180, ErrorMessage = "La longitud debe estar entre -180 y 180 grados")]
        public decimal Fact_Longitud { get; set; }

        [StringLength(90, ErrorMessage = "La referencia no puede exceder 90 caracteres")]
        public string? Fact_Referencia { get; set; }

        [StringLength(40, ErrorMessage = "El campo autorizado por no puede exceder 40 caracteres")]
        public string? Fact_AutorizadoPor { get; set; }

        [Required(ErrorMessage = "El usuario de creación es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El usuario de creación debe ser mayor a 0")]
        public int Usua_Creacion { get; set; }

        [Required(ErrorMessage = "Debe incluir al menos un producto")]
        [MinLength(1, ErrorMessage = "Debe incluir al menos un producto")]
        public List<VentaDetalleViewModel> DetallesFacturaInput { get; set; } = new List<VentaDetalleViewModel>();
    }

    public class VentaDetalleViewModel
    {
        [Required(ErrorMessage = "El ID del producto es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID del producto debe ser mayor a 0")]
        public int Prod_Id { get; set; }

        [Required(ErrorMessage = "La cantidad es requerida")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0")]
        public int FaDe_Cantidad { get; set; }
    }
}
