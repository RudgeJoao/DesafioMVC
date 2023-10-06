using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Torneio.Data;
using Torneio.Models;

namespace Torneio.Repositories
{
    public class LutadorRepository : ILutadorRepository
    {
        private readonly OracleDbContext _dbContext;

        public LutadorRepository(OracleDbContext dbContext)
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

        public async Task CreateLutador(Lutador lutador)
        {
            _dbContext.Add(lutador);
            await _dbContext.SaveChangesAsync();

        }

        public async Task UpdateLutador(int id, Lutador lutador)
        {
            _dbContext.Update(lutador);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteLutador(int id) 
        {
            var lutador = await _dbContext.Lutadores.FindAsync(id);
            if (lutador != null)
            {
                _dbContext.Lutadores.Remove(lutador);
            }

            await _dbContext.SaveChangesAsync();
        }

        public bool LutadorExists(int id) 
        {
            return (_dbContext.Lutadores?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
