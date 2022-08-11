﻿using System.ComponentModel.DataAnnotations;

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
        [Display(Name ="Nombre")]
        public string Nombre { get; set; }

        public DateTime FechReg { get; set; } = DateTime.Now;

        [Required]
        [MaxLength(100)]
        [Display(Name = "Direccion")]
        public string Direccion { get; set; }

        [Required]
        [MaxLength(9)]
        public int Telefono { get; set; }

        public virtual ICollection<DetalleIngreso> DetalleIngreso { get; set; }


    }
}
