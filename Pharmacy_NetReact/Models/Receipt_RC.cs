
using System.ComponentModel.DataAnnotations;


namespace NETCore_React.Models
{
    public class Receipt_RC
    {
       [Key]
       public int Id { get; set; }
       public string NroDoc { get; set; }
       public string Titulo { get; set; }
       public string Descripcion { get; set; }
       public string Moneda { get; set; }  //*
       public double Monto { get; set; }
       public string TipoDoc { get; set; } //*
       public string Direccion { get; set; }
       public string Nombres { get; set; }
       //public BadImageFormatException Logo { get; set; }

    }
}
