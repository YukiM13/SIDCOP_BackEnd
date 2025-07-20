#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIDCOP_Backend.Entities.Entities;

public partial class tbRoles
{
    [NotMapped]
    public int? Secuencia { get; set; }
    
    public int Role_Id { get; set; }

    public string Role_Descripcion { get; set; }

    public int Usua_Creacion { get; set; }

    [NotMapped]
    public string? UsuarioCreacion { get; set; }

    public DateTime Role_FechaCreacion { get; set; }

    public int? Usua_Modificacion { get; set; }

    [NotMapped]
    public string? UsuarioModificacion { get; set; }

    public DateTime? Role_FechaModificacion { get; set; }

    public bool Role_Estado { get; set; }

    public virtual tbUsuarios Usua_CreacionNavigation { get; set; }

    public virtual tbUsuarios Usua_ModificacionNavigation { get; set; }

    public virtual ICollection<tbPermisos> tbPermisos { get; set; } = new List<tbPermisos>();

    public virtual ICollection<tbUsuarios> tbUsuarios { get; set; } = new List<tbUsuarios>();
}