using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyBA.Models
{
    public class TipoUsuario
    {
        public int IdTipoUsuario { get; set; }

        public string ?Descripcion { get; set; }

    }
}
