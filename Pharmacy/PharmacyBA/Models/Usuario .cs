using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyBA.Models
{
    public class Usuario
    {
        [Key]
        public int CodUsuario { get; set; }

        [Display(Name = "Apellidos Completos")]
        [Required(ErrorMessage = "Debe de ingresar los apellidos")]
        [MaxLength(60, ErrorMessage = "El campo no debe de tener mas de 60 caracteres")]
        public string ?Apellidos { get; set; }

        [Display(Name = "Nombres")]
        [Required(ErrorMessage = "Debe de ingresar sus nombres")]
        [MaxLength(60, ErrorMessage = "El campo no debe de tener mas de 60 caracteres")]
        public string ?Nombres   { get; set; }

        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "Debe de ingresar ")]
        [MaxLength(20, ErrorMessage = "El campo no debe de tener mas de 20 caracteres")]
        public string User { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Debe de ingresar su contraseña ")]
        [MaxLength(20, ErrorMessage = "El campo no debe de tener mas de 20 caracteres. Verifique !!")]
        public string Password { get; set; }

        [Display(Name = "Documento de Identificacion")]
        [Required(ErrorMessage = "Debe de ingresar su documento ")]
        [MaxLength(9, ErrorMessage = "El campo no debe de tener mas de 9 caracteres")]
        public string ?DNI { get; set; }

        [Required(ErrorMessage = "Debe de ingresar el estado ")]
        public Boolean Estado { get; set; }

        [Display(Name = "Fecha de Registro")]
        public DateTime FechaReg { get; set; }


        // Foreign Key
        public int IdTipoUsuario { get; set; }
        public virtual TipoUsuario  ?TipoUsuario { get; set; }



    }
}
