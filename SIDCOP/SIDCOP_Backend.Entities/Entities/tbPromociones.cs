#nullable disable
using System;
using System.Collections.Generic;

namespace SIDCOP_Backend.Entities.Entities;

public partial class tbPromociones
{
    public int Prom_Id { get; set; }

    public string Prom_Descripcion { get; set; }

    public bool Prom_Tipo { get; set; }

    public string Prom_Aplicar { get; set; }

    public decimal Prom_Valor { get; set; }

    public DateTime Prom_FechaInicio { get; set; }

    public DateTime Prom_FechaFin { get; set; }

    public string Muni_Codigo { get; set; }

    public int? Sucu_Id { get; set; }

    public int Usua_Creacion { get; set; }

    public DateTime Prom_FechaCreacion { get; set; }

    public int? Usua_Modificacion { get; set; }

    public DateTime? Prom_FechaModificacion { get; set; }

    public bool Prom_Estado { get; set; }

    public virtual tbMunicipios Muni_CodigoNavigation { get; set; }

    public virtual tbSucursales Sucu { get; set; }

    public virtual tbUsuarios Usua_CreacionNavigation { get; set; }

    public virtual tbUsuarios Usua_ModificacionNavigation { get; set; }

    public virtual ICollection<tbPromocionesDetalle> tbPromocionesDetalle { get; set; } = new List<tbPromocionesDetalle>();
}