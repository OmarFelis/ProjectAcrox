using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace notienendqver.Models;

public partial class Beneficiario
{
    
    public int CodBeneficiario { get; set; }
    [Display(Name = "Nombre Completo")]
    [StringLength(250, ErrorMessage = "El nombre del almacén no puede exceder los 250 caracteres.")]
    public string? NombreCBeneficiario { get; set; }
    [Display(Name = "DNI")]
    [StringLength(120, ErrorMessage = "El nombre del almacén no puede exceder los 120 caracteres.")]
    public string? DniBeneficiario { get; set; }
    [Display(Name = "Estado")]
    public string? EstadoBeneficiario { get; set; }
    [Display(Name = "Fecha de nacimiento")]
    public DateOnly? FechBeneficiario { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Visitum> Visita { get; set; } = new List<Visitum>();

    public virtual ICollection<Viviendum> Vivienda { get; set; } = new List<Viviendum>();
}
