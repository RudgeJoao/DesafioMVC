using Torneio.Models;

namespace Torneio.Repositories
{
    public interface ITorneioRepository
    {
        Task<List<ResultadoTorneio>> ListarTorneiosAsync();
        Task<ResultadoTorneio> ListarTorneioAsync(int id);
        Task CreateTorneio(ResultadoTorneio resultadoTorneio);
    }
}
