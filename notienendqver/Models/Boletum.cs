using System;
using System.Collections.Generic;

namespace notienendqver.Models;

public partial class Boletum
{
    public int CodBoleta { get; set; }

    public DateOnly? FechaBoleta { get; set; }

    public int? TotalBoleta { get; set; }

    public string? EstadoBoleta { get; set; }

    public int? CodMaterial { get; set; }

    public int? CodVivienda { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual Material? CodMaterialNavigation { get; set; }

    public virtual Viviendum? CodViviendaNavigation { get; set; }

    public virtual ICollection<DetallePagoBoletum> DetallePagoBoleta { get; set; } = new List<DetallePagoBoletum>();

    public virtual ICollection<PagoBoletum> PagoBoleta { get; set; } = new List<PagoBoletum>();
}
