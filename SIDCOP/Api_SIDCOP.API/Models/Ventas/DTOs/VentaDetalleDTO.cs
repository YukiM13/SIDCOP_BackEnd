namespace Api_SIDCOP.API.Models.Ventas.DTOs
{
    public class VentaDetalleDTO
    {
        public int Prod_Id { get; set; }
        public int FaDe_Cantidad { get; set; }
        public decimal FaDe_PrecioUnitario { get; set; }
        public decimal FaDe_Impuesto { get; set; }
        public decimal FaDe_Descuento { get; set; }
        public decimal FaDe_Subtotal { get; set; }
        public decimal FaDe_Total { get; set; }
    }
}
