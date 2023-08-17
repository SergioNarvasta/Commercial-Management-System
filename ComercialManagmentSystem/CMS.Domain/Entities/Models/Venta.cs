using System.ComponentModel.DataAnnotations;

namespace ReactVentas.Models
{
    public class Venta_Comp
    {
        [Key]
        public int Codventa { get; set; }
        public int Descuento { get; set; }
        public Double Total { get; set; } 

        public DateTime Fecha { get; set; }

        public string TipoPago { get; set; }

        //Foreign Keys
        public int CodTipoComp { get; set; }
        public int CodUsuario { get; set; }
        public int CodCliente { get; set; }

        //Referencia de Relacion 
        //public virtual ICollection<DetalleVenta> DetalleVenta { get; set; }

    }
}
