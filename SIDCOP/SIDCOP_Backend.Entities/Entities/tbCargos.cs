#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIDCOP_Backend.Entities.Entities;

public partial class tbCargos
{
    [NotMapped]
    public int? Secuencia { get; set; }

    public int Carg_Id { get; set; }

    public string Carg_Descripcion { get; set; }

    public int Usua_Creacion { get; set; }

    public DateTime Carg_FechaCreacion { get; set; }

    public int? Usua_Modificacion { get; set; }

    public DateTime? Carg_FechaModificacion { get; set; }

    public bool Carg_Estado { get; set; }

    [NotMapped]
    public string UsuarioCreacion { get; set; }

    [NotMapped]
    public string UsuarioModificacion { get; set; }

    public virtual tbUsuarios Usua_CreacionNavigation { get; set; }

    public virtual tbUsuarios Usua_ModificacionNavigation { get; set; }

    public virtual ICollection<tbEmpleados> tbEmpleados { get; set; } = new List<tbEmpleados>();
}