using System;
using System.Collections.Generic;

namespace notienendqver.Models;

public partial class PagoBoletum
{
    public int CodPagoB { get; set; }

    public DateOnly? FechPago { get; set; }

    public int? MontoPago { get; set; }

    public string? EstadoPago { get; set; }

    public int? CodBoleta { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual Boletum? CodBoletaNavigation { get; set; }

    public virtual ICollection<DetallePagoBoletum> DetallePagoBoleta { get; set; } = new List<DetallePagoBoletum>();
}
