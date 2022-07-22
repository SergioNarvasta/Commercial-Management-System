using System.ComponentModel.DataAnnotations;

namespace PharmacyBA.Models
{
    public class DetalleVenta
    {
        [Key]
        public int CodDetVenta { get; set; }
        
        public int Cantidad { get; set; }
        public Double Precio    { get; set; }
        public Double Subtotal  { get; set; }

        public Double IGV { get; set; }

        public int CodProducto { get; set; }
        public virtual Producto Producto { get; set; }
        public int CodVenta { get; set; }
        public virtual Venta Venta { get; set; }
    }
}
