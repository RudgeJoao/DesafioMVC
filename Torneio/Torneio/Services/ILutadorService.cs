using Torneio.Models;

namespace Torneio.Services
{
    public interface ILutadorService
    {
        Task<List<Lutador>> GetLutadoresAsync();

        Task<Lutador> GetLutadorAsync(int? id);
        Task CreateLutador(Lutador lutador);

        Task UpdateLutador(int id, Lutador lutador);

        Task DeleteLutador(int id);

        bool LutadorExists(int id);


    }
}
