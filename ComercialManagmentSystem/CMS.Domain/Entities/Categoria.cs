using System;
using System.Collections.Generic;

namespace CMS.Domain.Entities
{
    public partial class Categoria
    {
        public Categoria()
        {
            Productos = new HashSet<Producto>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public bool isActive { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
