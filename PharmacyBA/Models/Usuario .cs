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
        public int Idusuario { get; set; }

        public string Apellidos { get; set; }
        public string Nombres   { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string DNI { get; set; }
        public boolean Estado { get; set; }
        public Date FechaIng { get; set; } 



             Tipo

    }
}
