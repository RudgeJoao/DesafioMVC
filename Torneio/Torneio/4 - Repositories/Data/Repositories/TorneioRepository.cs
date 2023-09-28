using System.Data.Entity;
using Torneio.Data;
using Torneio.Models;

namespace Torneio.Repositories
{
    public class TorneioRepository : ITorneioRepository
    {
        private readonly OracleDbContext _dbContext;

        public TorneioRepository(OracleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Lutador>> ListarLutadoresAsync(bool tracking = true)
        {
            var query = _dbContext.Lutadores.AsQueryable();

            if (!tracking)
                query = query.AsNoTracking();

            return await query.ToListAsync();
        }
    }
}
