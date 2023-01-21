using Microsoft.EntityFrameworkCore;
using NETCore_React.Models;

namespace Project.Data
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
        public DbSet<Receipt_RC> Receipt_RC { get; set; }
    }
}
