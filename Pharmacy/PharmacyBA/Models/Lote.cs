using System.ComponentModel.DataAnnotations;

namespace PharmacyBA.Models
{
    public class Lote
    {
        [Key]
        public int IdLote { get; set; }
            
        public int  Codigo { get; set; }
        public DateTime FechaVen { get; set; }
        
        public string RegSanit { get; set; }
    }
}
