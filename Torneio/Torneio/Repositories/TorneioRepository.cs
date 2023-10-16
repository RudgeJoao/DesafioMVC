using Microsoft.EntityFrameworkCore;
using Torneio.Data;
using Torneio.Models;

namespace Torneio.Repositories
{
    public class TorneioRepository : ITorneioRepository
    {
        private readonly OracleDbContext _context;

        public TorneioRepository(OracleDbContext context)
        {
            _context = context;
        }

        public async Task<List<ResultadoTorneio>> ListarTorneiosAsync() 
        {
            var query = await _context.ResultadoTorneios.ToListAsync();
            return query;
        }

        public async Task<ResultadoTorneio> ListarTorneioAsync(int id)
        {
            var query = await _context.ResultadoTorneios.FirstOrDefaultAsync(x => x.Id == id);
            return query;
        }

        public async Task CreateTorneio(ResultadoTorneio resultadoTorneio)
        {
            _context.Add(resultadoTorneio);
            await _context.SaveChangesAsync();
        }

    }
}
