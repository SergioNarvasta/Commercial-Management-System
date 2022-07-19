using System.ComponentModel.DataAnnotations;

namespace PharmacyBA.Models
{
    public class TipoComprobante
    {
        [Key]
        public int IdTipoComprobante { get; set; }

        [Display (Name ="Descipcion de tipo de comprobantes")]
        [Required(ErrorMessage = "Debe de ingresar el tipo de comprobante")]
        [MaxLength(60, ErrorMessage = "El campo no debe de tener mas de 60 caracteres")]
        public string Descripcion { get; set; }

    }
}
