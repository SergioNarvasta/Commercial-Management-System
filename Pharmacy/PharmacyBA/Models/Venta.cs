namespace PharmacyBA.Models
{
    public class Venta
    {
        public int Codventa { get; set; }
        public int Descuento { get; set; } = 0;
        public Double Total { get; set; } = 0;

        public DateTime Fecha { get; set; } = DateTime.Now;

        public string ?TipoPago { get; set; }

        //Foreign Keys
        public int CodTipoComp { get; set; }
        public int CodUsuario { get; set; }
        public int CodCliente { get; set; }
 
    }
}
