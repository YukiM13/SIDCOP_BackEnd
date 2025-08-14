using System;
using System.ComponentModel.DataAnnotations;

namespace Api_SIDCOP.API.Models.Ventas
{
    public class PagosCuentasPorCobrarViewModel
    {
        public int Pago_Id { get; set; }

        [Required(ErrorMessage = "El ID de la cuenta por cobrar es requerido")]
        public int CPCo_Id { get; set; }

        public DateTime Pago_Fecha { get; set; }

        [Required(ErrorMessage = "El monto del pago es requerido")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor a cero")]
        public decimal Pago_Monto { get; set; }

        [Required(ErrorMessage = "La forma de pago es requerida")]
        [StringLength(50, ErrorMessage = "La forma de pago no puede exceder los 50 caracteres")]
        public string Pago_FormaPago { get; set; }

        [StringLength(50, ErrorMessage = "El número de referencia no puede exceder los 50 caracteres")]
        public string Pago_NumeroReferencia { get; set; }

        [StringLength(200, ErrorMessage = "Las observaciones no pueden exceder los 200 caracteres")]
        public string Pago_Observaciones { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime Pago_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? Pago_FechaModificacion { get; set; }

        public bool Pago_Estado { get; set; }

        public bool Pago_Anulado { get; set; }

        public int? FoPa_Id { get; set; }

        // Propiedades adicionales para mostrar información relacionada - estas son opcionales para la inserción
        public string? UsuarioCreacion { get; set; }

        public string? UsuarioModificacion { get; set; }

        public int Clie_Id { get; set; }

        public string? Clie_NombreCompleto { get; set; }

        public string? Clie_RTN { get; set; }

        public int Fact_Id { get; set; }

        public string? Fact_Numero { get; set; }
    }

    public class AnularPagoViewModel
    {
        [Required(ErrorMessage = "El ID del pago es requerido")]
        public int Pago_Id { get; set; }

        [Required(ErrorMessage = "El ID del usuario que anula es requerido")]
        public int Usua_Modificacion { get; set; }

        [Required(ErrorMessage = "El motivo de anulación es requerido")]
        [StringLength(200, ErrorMessage = "El motivo de anulación no puede exceder los 200 caracteres")]
        public string Motivo_Anulacion { get; set; }
    }
}