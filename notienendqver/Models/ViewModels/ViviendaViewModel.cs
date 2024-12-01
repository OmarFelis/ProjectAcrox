using System.ComponentModel.DataAnnotations;
using System.Net;

namespace notienendqver.Models.ViewModels
{
    public class ViviendaViewModel
    {

        [Display(Name = "Codigo Vivienda")]
        public int CodVivienda { get; set; }

        [Display(Name = "Direccion Vivienda")]
        public string? DirVivienda { get; set; }

        [Display(Name = "Area Vivienda")]
        public string? AreaVivienda { get; set; }

        [Display(Name = "Estado Vivienda")]
        public string? EstadoVivienda { get; set; }

        [Display(Name = "Tipo Vivienda")]
        public string? TipoVivienda { get; set; }

        [Display(Name = "Nombre Completo")]
        public string? NombreCBeneficiario { get; set; }

        [Display(Name = "Fecha Creacion")]
        public DateTime? FechaCreacion { get; set; }

        [Display(Name = "Codigo Beneficiario")]
        public virtual Beneficiario? CodBeneficiarioNavigation { get; set; }
    }
}
