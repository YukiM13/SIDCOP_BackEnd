
#nullable disable
using System;
using System.Collections.Generic;

namespace SIDCOP_Backend.Entities.Entities;

public partial class tbAcciones
{
    public int Acci_Id { get; set; }

    public string Acci_Descripcion { get; set; }

    public virtual ICollection<tbPermisos> tbPermisos { get; set; } = new List<tbPermisos>();
}