using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Torneio.Models;

namespace Torneio.Data
{
    public class OracleDbContext : DbContext
    {
        public OracleDbContext (DbContextOptions<OracleDbContext> options)
            : base(options)
        {
        }

        public DbSet<Lutador> Lutador { get; set; } = default!;
    }
}
