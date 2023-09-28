using Torneio.Models;

namespace Torneio.Services
{
    public interface ITorneioService
    {
        Task<List<Lutador>> GetLutadoresAsync();

        Task<Lutador> GetLutadorAsync(int? id);
    }
}
