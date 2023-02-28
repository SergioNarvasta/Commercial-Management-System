using System.ComponentModel.DataAnnotations;

namespace Pharmacy.Models
{
    public class Lote
    {
        [Key]
        public int CodLote { get; set; }
            
        public DateTime FechaVen { get; set; }
        
        public string ?RegSanit { get; set; }

        public ICollection<Producto> Producto { get; set; }
    }
}
