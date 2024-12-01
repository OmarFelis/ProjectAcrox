using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace notienendqver.Models;

public partial class Material
{
    public int CodMaterial { get; set; }

    [Display(Name = "Nombre Material")]
    [StringLength(120, ErrorMessage = "El nombre del almacén no puede exceder los 120 caracteres.")]
    public string? NombMaterial { get; set; }

    [Display(Name = "Descripcion")]
    [StringLength(120, ErrorMessage = "El nombre del almacén no puede exceder los 120 caracteres.")]
    public string? DescrpMaterial { get; set; }

    [Display(Name = "Precio Material")]
    public double? PrecioMaterial { get; set; }

    public int? CodVivienda { get; set; }

    public int? CodProveedor { get; set; }

    public int? CodAlmacen { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Boletum> Boleta { get; set; } = new List<Boletum>();

    public virtual Almacen? CodAlmacenNavigation { get; set; }

    public virtual Proveedor? CodProveedorNavigation { get; set; }

    public virtual Viviendum? CodViviendaNavigation { get; set; }

    public virtual ICollection<Kardex> Kardices { get; set; } = new List<Kardex>();
}
