#nullable disable
using System;
using System.Collections.Generic;

namespace SIDCOP_Backend.Entities.Entities;

public partial class tbPreciosPorProducto
{
    public int PreP_Id { get; set; }

    public int? Prod_Id { get; set; }

    public decimal? PreP_PrecioContado { get; set; }

    public decimal? PreP_PrecioCredito { get; set; }

    public int? PreP_Secuencia { get; set; }

    public int? Usua_Modificacion { get; set; }

    public int? Usua_Creacion { get; set; }

    public DateTime? PreP_FechaCreacion { get; set; }

    public DateTime? PreP_FechaModificacion { get; set; }

    public bool PreP_Estado { get; set; }

    public virtual tbProductos Prod { get; set; }

    public virtual tbUsuarios Usua_CreacionNavigation { get; set; }

    public virtual tbUsuarios Usua_ModificacionNavigation { get; set; }
}