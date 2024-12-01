using System;
using System.Collections.Generic;

namespace notienendqver.Models;

public partial class PagoKardex
{
    public int CodPagoK { get; set; }

    public DateOnly? FechPago { get; set; }

    public int? MontoPago { get; set; }

    public string? EstadoPago { get; set; }

    public int? CodKardex { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual Kardex? CodKardexNavigation { get; set; }

    public virtual ICollection<DetallePagoKardex> DetallePagoKardices { get; set; } = new List<DetallePagoKardex>();
}
