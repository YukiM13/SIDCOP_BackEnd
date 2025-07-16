
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIDCOP_Backend.Entities.Entities;

public partial class tbCAIs
{
    public int NCai_Id { get; set; }

    public string NCai_Codigo { get; set; }

    public string NCai_Descripcion { get; set; }

    public int Usua_Creacion { get; set; }

    public DateTime NCai_FechaCreacion { get; set; }

    public int? Usua_Modificacion { get; set; }

    public DateTime? NCai_FechaModificacion { get; set; }

    public bool NCai_Estado { get; set; }

    [NotMapped]
    public int? Secuencia { get; set; }

    public virtual tbUsuarios Usua_CreacionNavigation { get; set; }

    public virtual tbUsuarios Usua_ModificacionNavigation { get; set; }

    public virtual ICollection<tbRegistrosCAI> tbRegistrosCAI { get; set; } = new List<tbRegistrosCAI>();
}