#nullable disable
using System;
using System.Collections.Generic;

namespace SIDCOP_Backend.Entities.Entities;

public partial class tbTrasladosDetalle
{
    public int TrDe_Id { get; set; }

    public int Tras_Id { get; set; }

    public int Prod_Id { get; set; }

    public int TrDe_Cantidad { get; set; }

    public string TrDe_Observaciones { get; set; }

    public int Usua_Creacion { get; set; }

    public DateTime TrDe_FechaCreacion { get; set; }

    public int? Usua_Modificacion { get; set; }

    public DateTime? TrDe_FechaModificacion { get; set; }

    public virtual tbProductos Prod { get; set; }

    public virtual tbTraslados Tras { get; set; }

    public virtual tbUsuarios Usua_CreacionNavigation { get; set; }

    public virtual tbUsuarios Usua_ModificacionNavigation { get; set; }
}