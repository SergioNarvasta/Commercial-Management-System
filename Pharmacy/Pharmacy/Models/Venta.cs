using System.ComponentModel.DataAnnotations;

namespace PharmacyBA.Models
{
    public class Venta
    {
        [Key]
        public int Codventa { get; set; }
        public int Descuento { get; set; } = 0;
        public Double Total { get; set; } = 0;

        public DateTime Fecha { get; set; } = DateTime.Now;

        public string ?TipoPago { get; set; }

        //Foreign Keys
        public int CodTipoComp { get; set; }
        public virtual TipoComprobante TipoComprobante { get; set; }
        public int CodUsuario { get; set; }
        public virtual Usuario  Usuario { get; set; }
        public int CodCliente { get; set; }
        public virtual Cliente Cliente      { get; set; }

        //Referencia de Relacion 
        public virtual ICollection<DetalleVenta> DetalleVenta { get; set; }

    }
}
