using Microsoft.EntityFrameworkCore;
using Torneio.Models;

namespace TorneioAPI.Data
{
    public class OracleDbContext : DbContext
    {
        public OracleDbContext(DbContextOptions<OracleDbContext> options) : base(options)
        {
        }
        public DbSet<Lutador> Lutadores { get; set; }
    }
}
