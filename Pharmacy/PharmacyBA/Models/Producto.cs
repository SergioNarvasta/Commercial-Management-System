using System.ComponentModel.DataAnnotations;

namespace PharmacyBA.Models
{
    public class Producto
    {
        [Key]
        public int CodProducto { get; set; }

        [Display(Name = "Codigo")]
        [Required(ErrorMessage = "Debe de ingresar sus Codigo del producto")]
        [MaxLength(20, ErrorMessage = "El campo no debe de tener mas de 20 caracteres")]
        public string Correlativo { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Debe de ingresar sus Nombre del producto")]
        [MaxLength(60, ErrorMessage = "El campo no debe de tener mas de 60 caracteres")]
        public string Nombre { get; set; }

        [Display(Name = "Nombre Cientifico")]
        [Required(ErrorMessage = "Debe de ingresar sus Nombre Cientifico del producto")]
        [MaxLength(60, ErrorMessage = "El campo no debe de tener mas de 60 caracteres")]
        public string? NombreCientifico { get; set; } //DCI 

        [Display(Name = "Concentracion")]
        [Required(ErrorMessage = "Debe de ingresar la Concentracion del producto")]
        [MaxLength(10, ErrorMessage = "El campo no debe de tener mas de 10 caracteres")]
        public decimal? Concentracion { get; set; }

        [Display(Name = "Presentacion")]
        [Required(ErrorMessage = "Debe de ingresar la presentacion del producto")]
        [MaxLength(20, ErrorMessage = "El campo no debe de tener mas de 20 caracteres")]
        public string? Presentacion { get; set; }

        [Display(Name = "PrecioVenta")]
        [Required(ErrorMessage = "Debe de ingresar el precio de venta del producto")]
        [MaxLength(10, ErrorMessage = "El campo no debe de tener mas de 20 caracteres")]
        public decimal PrecioVenta { get; set; }

        [Display(Name = "Cantidad")]
        [Required(ErrorMessage = "Debe de ingresar la cantidad del producto")]
        [MaxLength(10, ErrorMessage = "El campo no debe de tener mas de 10 caracteres")]
        public decimal Cantidad { get; set; }

        [Display(Name = "Restriccion")]
        [Required(ErrorMessage = "Debe de ingresar 0 producto si el producto no tiene restriccion y 1 si lo tiene")]
        [MaxLength(5, ErrorMessage = "El campo no debe de tener mas de 5 caracteres")]
        public Boolean Restriccion { get; set; }

        //Foreign Key
        public int CodLote { get; set; }
        public virtual Lote Lote { get; set; }


        public virtual ICollection<DetalleIngreso> DetalleIngreso { get; set; }
        public virtual ICollection<DetalleVenta> DetalleVenta { get; set; }
    }
}
