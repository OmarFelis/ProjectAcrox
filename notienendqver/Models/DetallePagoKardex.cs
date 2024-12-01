using System;
using System.Collections.Generic;

namespace notienendqver.Models;

public partial class DetallePagoKardex
{
    public int CodDetalle { get; set; }

    public int CodKardex { get; set; }

    public int CodPagoK { get; set; }

    public string? Descp { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual Kardex CodKardexNavigation { get; set; } = null!;

    public virtual PagoKardex CodPagoKNavigation { get; set; } = null!;
}
