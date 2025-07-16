#nullable disable
using System;
using System.Collections.Generic;

namespace SIDCOP_Backend.Entities.Entities;

public partial class tbDescuentos
{
    public int Desc_Id { get; set; }

    public string Desc_Descripcion { get; set; }

    public bool Desc_Tipo { get; set; }

    public int Cana_Id { get; set; }

    public string Desc_Aplicar { get; set; }

    public decimal Desc_Valor { get; set; }

    public DateTime Desc_FechaInicio { get; set; }

    public DateTime Desc_FechaFin { get; set; }

    public string Desc_Observaciones { get; set; }

    public int Usua_Creacion { get; set; }

    public DateTime Desc_FechaCreacion { get; set; }

    public int? Usua_Modificacion { get; set; }

    public DateTime? Desc_FechaModificacion { get; set; }

    public bool Desc_Estado { get; set; }

    public virtual tbCanales Cana { get; set; }

    public virtual tbUsuarios Usua_CreacionNavigation { get; set; }

    public virtual tbUsuarios Usua_ModificacionNavigation { get; set; }

    public virtual ICollection<tbDescuentosDetalle> tbDescuentosDetalle { get; set; } = new List<tbDescuentosDetalle>();
}