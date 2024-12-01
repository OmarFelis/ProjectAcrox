using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace notienendqver.Models;

public partial class Proveedor
{
    public int CodProveedor { get; set; }

    [Display(Name = "Nombre del Proveedor")]
    [StringLength(120, ErrorMessage = "El nombre del almacén no puede exceder los 120 caracteres.")]
    public string? NombProveedor { get; set; }

    [Display(Name = "Teléfono")]
    [StringLength(120, ErrorMessage = "El nombre del almacén no puede exceder los 120 caracteres.")]
    public string? TelfProveedor { get; set; }

    [Display(Name = "Dirección completa")]
    [StringLength(120, ErrorMessage = "El nombre del almacén no puede exceder los 120 caracteres.")]
    public string? DirProveedor { get; set; }

    [Display(Name = "Estado")]
    public string? EstadoProveedor { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Kardex> Kardices { get; set; } = new List<Kardex>();

    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();
}
