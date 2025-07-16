#nullable disable
using System;
using System.Collections.Generic;

namespace SIDCOP_Backend.Entities.Entities;

public partial class tbFacturasDetalle
{
    public int FaDe_Id { get; set; }

    public int Fact_Id { get; set; }

    public int Prod_Id { get; set; }

    public int FaDe_Cantidad { get; set; }

    public decimal FaDe_PrecioUnitario { get; set; }

    public decimal FaDe_Impuesto { get; set; }

    public decimal FaDe_Descuento { get; set; }

    public decimal FaDe_Subtotal { get; set; }

    public decimal FaDe_Total { get; set; }

    public int Usua_Creacion { get; set; }

    public DateTime FaDe_FechaCreacion { get; set; }

    public int? Usua_Modificacion { get; set; }

    public DateTime? FaDe_FechaModificacion { get; set; }

    public bool FaDe_Estado { get; set; }

    public virtual tbFacturas Fact { get; set; }

    public virtual tbProductos Prod { get; set; }

    public virtual tbUsuarios Usua_CreacionNavigation { get; set; }

    public virtual tbUsuarios Usua_ModificacionNavigation { get; set; }
}