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

        public DbSet<PharmacyBA.Models.TipoUsuario> TipoUsuario { get; set; } = default!;
    }
}
