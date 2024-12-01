using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace notienendqver.Models;

public partial class Viviendum
{
    public int CodVivienda { get; set; }

    [Display(Name = "Dirección Completa ")]
    [StringLength(120, ErrorMessage = "El nombre del almacén no puede exceder los 120 caracteres.")]
    public string? DirVivienda { get; set; }

    [Display(Name = "Área de la vivienda")]
    [StringLength(120, ErrorMessage = "El nombre del almacén no puede exceder los 120 caracteres.")]
    public string? AreaVivienda { get; set; }

    [Display(Name = "Estado")]
    [StringLength(120, ErrorMessage = "El nombre del almacén no puede exceder los 120 caracteres.")]
    public string? EstadoVivienda { get; set; }

    [Display(Name = "Tipo de Vivienda")]
    [StringLength(120, ErrorMessage = "El nombre del almacén no puede exceder los 120 caracteres.")]
    public string? TipoVivienda { get; set; }

    public int? CodBeneficiario { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Boletum> Boleta { get; set; } = new List<Boletum>();

    public virtual Beneficiario? CodBeneficiarioNavigation { get; set; }

    public virtual ICollection<Contrato> Contratos { get; set; } = new List<Contrato>();

    public virtual ICollection<Kardex> Kardices { get; set; } = new List<Kardex>();

    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();

    public virtual ICollection<Registro> Registros { get; set; } = new List<Registro>();

    public virtual ICollection<Visitum> Visita { get; set; } = new List<Visitum>();
}
