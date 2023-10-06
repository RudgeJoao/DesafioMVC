using Torneio.Models;

namespace Torneio.Repositories
{
    public interface ILutadorRepository
    {
        Task<List<Lutador>> ListarLutadoresAsync();

        Task<Lutador> GetLutadorAsync(int? id);

        Task CreateLutador(Lutador lutador);

        Task UpdateLutador(int id, Lutador lutador);

        Task DeleteLutador(int id);

        bool LutadorExists(int id);
    }
}
