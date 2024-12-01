using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace notienendqver.Models;

public partial class Visitum
{
    public int CodVisita { get; set; }

    [Display(Name = "Fecha de la visita programada")]
    [StringLength(150, ErrorMessage = "El nombre del almacén no puede exceder los 120 caracteres.")]
    public string? FechaVisita { get; set; }

    [Display(Name = "Descripcion")]
    [StringLength(200, ErrorMessage = "El nombre del almacén no puede exceder los 120 caracteres.")]
    public string? DespVisita { get; set; }

    public int? CodBeneficiario { get; set; }

    public int? CodVivienda { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual Beneficiario? CodBeneficiarioNavigation { get; set; }

    public virtual Viviendum? CodViviendaNavigation { get; set; }
}
