#nullable disable
using System;
using System.Collections.Generic;

namespace SIDCOP_Backend.Entities.Entities;

public partial class tbColonias
{
    public int Colo_Id { get; set; }

    public string Colo_Descripcion { get; set; }

    public string Muni_Codigo { get; set; }

    public int Usua_Creacion { get; set; }

    public DateTime Colo_FechaCreacion { get; set; }

    public int? Usua_Modificacion { get; set; }

    public DateTime? Colo_FechaModificacion { get; set; }

    public virtual tbMunicipios Muni_CodigoNavigation { get; set; }

    public virtual tbUsuarios Usua_CreacionNavigation { get; set; }

    public virtual tbUsuarios Usua_ModificacionNavigation { get; set; }

    public virtual ICollection<tbClientes> tbClientes { get; set; } = new List<tbClientes>();

    public virtual ICollection<tbConfiguracionFacturas> tbConfiguracionFacturas { get; set; } = new List<tbConfiguracionFacturas>();

    public virtual ICollection<tbEmpleados> tbEmpleados { get; set; } = new List<tbEmpleados>();

    public virtual ICollection<tbProveedores> tbProveedores { get; set; } = new List<tbProveedores>();

    public virtual ICollection<tbSucursales> tbSucursales { get; set; } = new List<tbSucursales>();

    public virtual ICollection<tbVendedores> tbVendedores { get; set; } = new List<tbVendedores>();
}