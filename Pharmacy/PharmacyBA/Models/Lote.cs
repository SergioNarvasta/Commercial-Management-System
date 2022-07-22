using System.ComponentModel.DataAnnotations;

namespace PharmacyBA.Models
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
