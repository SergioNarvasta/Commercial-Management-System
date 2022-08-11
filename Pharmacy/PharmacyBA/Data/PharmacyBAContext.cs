using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PharmacyBA.Models;

namespace PharmacyBA.Data
{
    public class PharmacyBAContext : DbContext
    {
        public PharmacyBAContext (DbContextOptions<PharmacyBAContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-6CK5JQAF;Database=Pharmacy;Trusted_Connection=true; MultipleActiveResultSets=true;");
        }

        public DbSet<PharmacyBA.Models.Cliente> Cliente { get; set; }
        public DbSet<PharmacyBA.Models.DetalleIngreso> DetalleIngreso { get; set; }
        public DbSet<PharmacyBA.Models.Ingreso> Ingreso { get; set; }
        public DbSet<PharmacyBA.Models.DetalleVenta> DetalleVenta { get; set; }
        public DbSet<PharmacyBA.Models.Lote> Lote { get; set; }
        public DbSet<PharmacyBA.Models.Producto> Producto { get; set; }
        public DbSet<PharmacyBA.Models.Proveedor> Proveedor { get; set; }
        public DbSet<PharmacyBA.Models.TipoComprobante> TipoComprobante { get; set; }
        public DbSet<PharmacyBA.Models.Usuario> Usuario { get; set; }
        public DbSet<PharmacyBA.Models.Venta> Venta { get; set; }
        public DbSet<PharmacyBA.Models.TipoUsuario> TipoUsuario { get; set; }
    }
}
