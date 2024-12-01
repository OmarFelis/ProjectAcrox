using System.ComponentModel.DataAnnotations;

namespace notienendqver.Models.ViewModels
{
    public class MaterialModel
    {

        [Display(Name = "Nombre Material")]
        public string? NombMaterial { get; set; }

        [Display(Name = "Descripcion")]
        public string? DescrpMaterial { get; set; }

        [Display(Name = "Precio Material")]
        public double? PrecioMaterial { get; set; }

        public virtual Almacen? CodAlmacenNavigation { get; set; }

        public virtual Proveedor? CodProveedorNavigation { get; set; }

        public virtual Viviendum? CodViviendaNavigation { get; set; }

    }
}
