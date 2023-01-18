using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Models;

namespace Pharmacy.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=HDVMSQLDES;Database=Z_Pharmacy;User ID=sa; Password=S0p0rt3; MultipleActiveResultSets=true;");
        }
        
        public DbSet<Pharmacy.Models.Producto> Producto { get; set; }
        public DbSet<Pharmacy.Models.Proveedor> Proveedor { get; set; }
        public DbSet<Pharmacy.Models.Venta> Venta { get; set; }
        
       /* public DbSet<Pharmacy.Models.Cliente> Cliente { get; set; }
        public DbSet<Pharmacy.Models.DetalleIngreso> DetalleIngreso { get; set; }
        public DbSet<Pharmacy.Models.Ingreso> Ingreso { get; set; }
        public DbSet<Pharmacy.Models.DetalleVenta> DetalleVenta { get; set; }
        public DbSet<Pharmacy.Models.Lote> Lote { get; set; }
        public DbSet<Pharmacy.Models.TipoComprobante> TipoComprobante { get; set; }
        public DbSet<Pharmacy.Models.Usuario> Usuario { get; set; }
        public DbSet<Pharmacy.Models.TipoUsuario> TipoUsuario { get; set; }*/
    }
}