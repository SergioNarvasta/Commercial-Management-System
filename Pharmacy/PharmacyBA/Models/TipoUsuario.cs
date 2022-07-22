using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyBA.Models
{
    public class TipoUsuario
    {
        [Key]
        public int CodTipoUsu { get; set; }

        public string ?Descripcion { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }

    }
}
