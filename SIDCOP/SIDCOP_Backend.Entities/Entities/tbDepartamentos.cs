#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIDCOP_Backend.Entities.Entities;

public partial class tbDepartamentos
{
    public string Depa_Codigo { get; set; }

    public string Depa_Descripcion { get; set; }

    public int Usua_Creacion { get; set; }

    public DateTime Depa_FechaCreacion { get; set; }

    public int? Usua_Modificacion { get; set; }

    public DateTime? Depa_FechaModificacion { get; set; }

    [NotMapped]
    public string UsuarioCreacion { get; set; }

    [NotMapped]
    public string UsuarioModificacion { get; set; }

    public virtual tbUsuarios Usua_CreacionNavigation { get; set; }

    public virtual tbUsuarios Usua_ModificacionNavigation { get; set; }

    public virtual ICollection<tbMunicipios> tbMunicipios { get; set; } = new List<tbMunicipios>();
}