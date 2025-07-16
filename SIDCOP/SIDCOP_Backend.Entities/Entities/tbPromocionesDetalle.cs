#nullable disable
using System;
using System.Collections.Generic;

namespace SIDCOP_Backend.Entities.Entities;

public partial class tbPromocionesDetalle
{
    public int PrDe_Id { get; set; }

    public int Prom_Id { get; set; }

    public int PrDe_IdReferencia { get; set; }

    public int Usua_Creacion { get; set; }

    public DateTime PrDe_FechaCreacion { get; set; }

    public int? Usua_Modificacion { get; set; }

    public DateTime? PrDe_FechaModificacion { get; set; }

    public bool PrDe_Estado { get; set; }

    public virtual tbPromociones Prom { get; set; }

    public virtual tbUsuarios Usua_CreacionNavigation { get; set; }

    public virtual tbUsuarios Usua_ModificacionNavigation { get; set; }
}