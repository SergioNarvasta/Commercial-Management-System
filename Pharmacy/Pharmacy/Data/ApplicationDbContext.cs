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
    }
}