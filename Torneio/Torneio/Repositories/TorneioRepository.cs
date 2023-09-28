using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Lutador>> ListarLutadoresAsync()
        {
            var query = await _dbContext.Lutadores.ToListAsync();
            return query;

        }

        public async Task<Lutador> GetLutadorAsync(int? id)
        {
           var query = await _dbContext.Lutadores.FirstOrDefaultAsync(x => x.Id == id);

            return query;

        }

    }
}
