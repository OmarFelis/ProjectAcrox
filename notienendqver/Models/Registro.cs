using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace notienendqver.Models;

public partial class Registro
{
    public int CodRegistro { get; set; }

    [Display(Name = "Fecha de Registro")]
    public DateOnly? FechRegistro { get; set; }

    [Display(Name = "Descripcion")]
    public string? DescrpRegistro { get; set; }

    [Display(Name = "Tipo de registro")]
    public string? TipoRegistro { get; set; }

    public int? CodVivienda { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual Viviendum? CodViviendaNavigation { get; set; }
}
