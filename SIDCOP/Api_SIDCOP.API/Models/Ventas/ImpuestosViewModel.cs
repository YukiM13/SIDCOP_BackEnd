namespace Api_SIDCOP.API.Models.Ventas
{
    public class ImpuestosViewModel
    {

        public int Impu_Id { get; set; }

        public string Impu_Descripcion { get; set; }

        public decimal Impu_Valor { get; set; }

        public int Usua_Creacion { get; set; }

        public DateTime Impu_FechaCreacion { get; set; }

        public int? Usua_Modificacion { get; set; }

        public DateTime? Impu_FechaModificacion { get; set; }

        public bool Impu_Estado { get; set; }
        public int? Secuencia { get; set; }

    }
}
