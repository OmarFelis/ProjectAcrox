using System;
using System.Collections.Generic;

namespace notienendqver.Models;

public partial class Kardex
{
    public int CodKardex { get; set; }

    public string? DescrpKardex { get; set; }

    public int? CodProveedor { get; set; }

    public int? CodMaterial { get; set; }

    public int? CodVivienda { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual Material? CodMaterialNavigation { get; set; }

    public virtual Proveedor? CodProveedorNavigation { get; set; }

    public virtual Viviendum? CodViviendaNavigation { get; set; }

    public virtual ICollection<DetallePagoKardex> DetallePagoKardices { get; set; } = new List<DetallePagoKardex>();

    public virtual ICollection<PagoKardex> PagoKardices { get; set; } = new List<PagoKardex>();
}
