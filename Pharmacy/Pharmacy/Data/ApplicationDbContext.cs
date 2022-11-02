using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PharmacyBA.Models;

namespace Pharmacy.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<PharmacyBA.Models.Producto> Producto { get; set; }
        public DbSet<PharmacyBA.Models.Proveedor> Proveedor { get; set; }
        public DbSet<PharmacyBA.Models.Venta> Venta { get; set; }
        public DbSet<PharmacyBA.Models.Cliente> Cliente { get; set; }
        public DbSet<PharmacyBA.Models.DetalleIngreso> DetalleIngreso { get; set; }
        public DbSet<PharmacyBA.Models.Ingreso> Ingreso { get; set; }
        public DbSet<PharmacyBA.Models.DetalleVenta> DetalleVenta { get; set; }
        public DbSet<PharmacyBA.Models.Lote> Lote { get; set; }
        public DbSet<PharmacyBA.Models.TipoComprobante> TipoComprobante { get; set; }
        public DbSet<PharmacyBA.Models.Usuario> Usuario { get; set; }
        public DbSet<PharmacyBA.Models.TipoUsuario> TipoUsuario { get; set; }
    }
}