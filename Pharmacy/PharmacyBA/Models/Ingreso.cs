using System;
using System.ComponentModel.DataAnnotations;

namespace PharmacyBA.Models
{
    public class Ingreso
    {
        [Key]
        public int CodIngreso { get; set; }
        
        public DateTime FecIng { get; set; } = DateTime.Now;

        public Double Totalcompra { get; set; }

        public int CodUsuario { get; set; }

    }
}
