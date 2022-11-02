using System.ComponentModel.DataAnnotations;

namespace Pharmacy.Models
{
    public class DetalleIngreso
    {
        [Key]
        public int CodDetIng { get; set; }
        public int Cantidad { get; set; }
        public string ?UniMedida { get; set; }
        public Double Precio { get; set; }
        public Double SubTotal { get; set; }

        //Foreign Key
        public int CodIngreso { get; set; }
        public virtual Ingreso ?Ingreso { get; set; }
        public int CodProducto { get; set; }
        public virtual Producto ?Producto { get; set; }
        public int CodProveedor { get; set; }
        public virtual Proveedor ?Proveedor  { get; set; }
    }
}
