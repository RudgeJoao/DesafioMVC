using Torneio.Models;

namespace Torneio.Repositories
{
    public interface ITorneioRepository
    {
        Task<List<Lutador>> ListarLutadoresAsync();

        Task<Lutador> GetLutadorAsync(int? id);
    }
}
