using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace notienendqver.Models;

public partial class Almacen
{
    public int CodAlmacen { get; set; }

    [Display(Name = "Nombre del Almacen")]
    [StringLength(120, ErrorMessage = "El nombre del almacén no puede exceder los 120 caracteres.")]
    public string? NombreAlmacen { get; set; }

    [Display(Name = "Dirección completa")]
    [StringLength(120, ErrorMessage = "El nombre del almacén no puede exceder los 120 caracteres.")]
    public string? LugarAlmacen { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();
}
