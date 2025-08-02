namespace Api_SIDCOP.API.Models.Ventas.DTOs
{
    public class VentaInsertarDTO
    {
        public string Fact_Numero { get; set; }
        public string Fact_TipoDeDocumento { get; set; }
        public int RegC_Id { get; set; }
        public int Clie_Id { get; set; }
        public int Vend_Id { get; set; }
        public string Fact_TipoVenta { get; set; }
        public DateTime Fact_FechaEmision { get; set; }
        public DateTime Fact_FechaLimiteEmision { get; set; }
        public string Fact_RangoInicialAutorizado { get; set; }
        public string Fact_RangoFinalAutorizado { get; set; }

        public decimal Fact_TotalImpuesto15 { get; set; }
        public decimal Fact_TotalImpuesto18 { get; set; }
        public decimal Fact_ImporteExento { get; set; }
        public decimal Fact_ImporteGravado15 { get; set; }
        public decimal Fact_ImporteGravado18 { get; set; }
        public decimal Fact_ImporteExonerado { get; set; }
        public decimal Fact_TotalDescuento { get; set; }

        public decimal Fact_Subtotal { get; set; }
        public decimal Fact_Total { get; set; }

        public decimal Fact_Latitud { get; set; }
        public decimal Fact_Longitud { get; set; }

        public string Fact_Referencia { get; set; }
        public string Fact_AutorizadoPor { get; set; }
        public int Usua_Creacion { get; set; }

        public List<VentaDetalleDTO> DetallesFactura { get; set; }
    }
}
