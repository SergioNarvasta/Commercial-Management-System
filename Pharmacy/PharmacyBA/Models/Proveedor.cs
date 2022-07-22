using System.ComponentModel.DataAnnotations;

namespace PharmacyBA.Models
{
    public class Proveedor
    {
        [Key]
        public int CodProveedor { get; set; }

        [Required]
        [MaxLength(14)]
        [Display(Name = "Nro Ruc")]
        public string Ruc { get; set; }

        [MaxLength(15)]
        public string Codigo { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name ="Descripcion")]
        public string ?Nombre { get; set; }

        public DateTime FechReg { get; set; } = DateTime.Now;

        public virtual ICollection<DetalleIngreso> DetalleIngreso { get; set; }


    }
}
