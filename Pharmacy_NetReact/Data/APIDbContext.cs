using Microsoft.EntityFrameworkCore;
using NETCore_React.Models;

namespace NETCore_React.Data
{
    public class APIDbContext :DbContext
    {
        private readonly string connectionString;

        public APIDbContext(DbContextOptions<APIDbContext> options, IConfiguration configuration)
           : base(options)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
        public DbSet<Producto> Producto { get; set; }
    }
}
