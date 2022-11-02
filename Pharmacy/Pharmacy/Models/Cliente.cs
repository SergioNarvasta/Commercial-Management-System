using System.ComponentModel.DataAnnotations;

namespace PharmacyBA.Models
{
    public class Cliente
    {
        [Key]
        public int CodCliente { get; set; }

        [Display(Name = "Nombres")]
        [Required(ErrorMessage = "Debe de ingresar sus nombres")]
        [MaxLength(60, ErrorMessage = "El campo no debe de tener mas de 60 caracteres")]
        public string ?Nombres { get; set; }
       
        [Display(Name = "Documento de Identificacion")]
        [MaxLength(9, ErrorMessage = "El campo no debe de tener mas de 9 caracteres")]
        public string ?DNI { get; set; }

        [Display(Name = "Nro de RUC")]
        [MaxLength(15, ErrorMessage = "El campo no debe de tener mas de 15 caracteres")]
        public string ?RUC { get; set; }

        [Display(Name = "RazonSocial")]
        [MaxLength(60, ErrorMessage = "El campo no debe de tener mas de 60 caracteres")]
        public string  ?RazonSocial { get; set; }

        [Display(Name = "Direccion ")]
        [Required(ErrorMessage = "Debe de ingresar sus nombres")]
        [MaxLength(60, ErrorMessage = "El campo no debe de tener mas de 60 caracteres")]
        public string? Direccion { get; set; }

        public int Telefono { get; set; }

        public string ?Correo { get; set; }

        [Display(Name = "Fecha de Registro")]
        public DateTime FechaReg { get; set; } = DateTime.Now;

        //Referencia de Relacion 
        public virtual ICollection<Venta> Venta { get; set; }
      

    }
}
