using System;
using System.Collections.Generic;

namespace notienendqver.Models;

public partial class DetallePagoBoletum
{
    public int CodDetalle { get; set; }

    public int CodBoleta { get; set; }

    public int CodPagoB { get; set; }

    public string? Descrp { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual Boletum CodBoletaNavigation { get; set; } = null!;

    public virtual PagoBoletum CodPagoBNavigation { get; set; } = null!;
}
