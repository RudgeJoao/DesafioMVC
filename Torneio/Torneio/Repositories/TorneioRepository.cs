using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
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

        public async Task<List<Lutador>> ListarLutadoresAsync()
        {
            var query = await _context.Lutadores.ToListAsync();
            return query;
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

        public async Task<ResultadoTorneio> SaveResultadoTorneio(Lutador lutador, double taxaDeVitorias)
        {
            var torneio = new ResultadoTorneio();

            torneio.Data = DateTime.Today;
            torneio.Vencedor = lutador.Nome;
            torneio.TaxaDeVitorias = taxaDeVitorias;

            await CreateTorneio(torneio);
            return torneio;
        }

        public async Task CreateTorneio(ResultadoTorneio resultadoTorneio)
        {
            _context.Add(resultadoTorneio);
            await _context.SaveChangesAsync();
        }

    }
}
