
using Microsoft.EntityFrameworkCore;
using Torneio.Models;

namespace Torneio.Data
{
    public class OracleDbContext : DbContext
    {
        public OracleDbContext (DbContextOptions options) : base(options)
        {
        }

        public DbSet<Lutador> Lutadores { get; set; } = default!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(NecessityMap).Assembly);
            modelBuilder.HasDefaultSchema("RM87725");
            base.OnModelCreating(modelBuilder);
        }
    }

}
