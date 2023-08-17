using System.ComponentModel.DataAnnotations;

namespace ReactVentas.Models
{
    public class DetalleVenta_Compl
    {
        [Key]
        public int CodDetVenta { get; set; }
        
        public int Cantidad { get; set; }
        public Double Precio    { get; set; }
        public Double Subtotal  { get; set; }
        public Double IGV { get; set; }

        public int CodProducto { get; set; }
        public int CodVenta { get; set; }
    }
}
