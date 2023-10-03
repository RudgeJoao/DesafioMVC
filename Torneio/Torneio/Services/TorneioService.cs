using Torneio.Controllers;
using Torneio.Data;
using Torneio.Models;
using Torneio.Repositories;

namespace Torneio.Services
{
    public class TorneioService : ITorneioService
    {
        private readonly ITorneioRepository _torneioRepository;

        public TorneioService(ITorneioRepository torneioRepository)
        {
            _torneioRepository = torneioRepository;
        }
        public async Task<List<Lutador>> GetLutadoresAsync()
        {
            return await _torneioRepository.ListarLutadoresAsync();
        }

        public async Task<Lutador> GetLutadorAsync(int? id)
        {
            var lutador = await _torneioRepository.GetLutadorAsync(id);

            if (id == null || _torneioRepository.GetLutadorAsync(id) == null)
            {
                return NotFound();
            }

            if (lutador is null)
            {
                return NotFound();
            }
            return lutador;
        }

        private Lutador NotFound()
        {
            throw new NotImplementedException();
        }

        public async Task CreateLutador(Lutador lutador)
        {
            _torneioRepository.CreateLutador(lutador);
        }

        public async Task UpdateLutador(int id, Lutador lutador)
        {
            _torneioRepository.UpdateLutador(id, lutador);
        }

        public async Task DeleteLutador(int id)
        { 
            _torneioRepository.DeleteLutador(id);
        }
        public bool LutadorExists(int id)
        { 
            bool existe = _torneioRepository.LutadorExists(id);

            return existe;
        }

    }
}
