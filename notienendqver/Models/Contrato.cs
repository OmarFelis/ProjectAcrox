using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace notienendqver.Models;

public partial class Contrato
{
    public int CodContrato { get; set; }

    [Display(Name = "Código de Vivienda")]
    public int CodVivienda { get; set; }

    [Display(Name = "Tipo de Contrato")]
    [StringLength(150, ErrorMessage = "El nombre del almacén no puede exceder los 150 caracteres.")]

    public string? TipoContrato { get; set; }

    [Display(Name = "Fecha de Creación")]
    public DateTime? FechaCreacion { get; set; }

    [Display(Name = "Nombre de Vivienda")]
    public virtual Viviendum? CodViviendaNavigation { get; set; } 
}
