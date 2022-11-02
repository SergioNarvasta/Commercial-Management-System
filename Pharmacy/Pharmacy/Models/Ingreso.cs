using System;
using System.ComponentModel.DataAnnotations;

namespace Pharmacy.Models
{
    public class Ingreso
    {
        [Key]
        public int CodIngreso { get; set; }
        
        public DateTime FecIng { get; set; } = DateTime.Now;

        public Double Totalcompra { get; set; }

        public int CodUsuario { get; set; } 
        public virtual Usuario ?Usuario  { get; set; }

        public virtual ICollection<DetalleIngreso> DetalleIngreso { get; set; }  

    }
}
