using Torneio.Models;

namespace Torneio.Repositories
{
    public interface ITorneioRepository
    {
        Task<List<Lutador>> ListarLutadoresAsync(bool tracking = true);
    }
}
