using Torneio.Controllers;
using Torneio.Data;
using Torneio.Models;
using Torneio.Repositories;

namespace Torneio.Services
{
    public class LutadorService : ILutadorService
    {
        private readonly ILutadorRepository _lutadorRepository;
        private readonly ITorneioRepository _torneioRepository;

        public LutadorService(ILutadorRepository lutadorRepository, ITorneioRepository torneioRepository)
        {
            _lutadorRepository = lutadorRepository;
            _torneioRepository = torneioRepository;
        }
        public async Task<List<Lutador>> GetLutadoresAsync()
        {
            return await _lutadorRepository.ListarLutadoresAsync();
        }

        public async Task<Lutador> GetLutadorAsync(int? id)
        {
            var lutador = await _lutadorRepository.GetLutadorAsync(id);

            if (id == null || _lutadorRepository.GetLutadorAsync(id) == null)
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
            await _lutadorRepository.CreateLutador(lutador);
        }

        public async Task UpdateLutador(int id, Lutador lutador)
        {
            await _lutadorRepository.UpdateLutador(id, lutador);
        }

        public async Task DeleteLutador(int id)
        { 
            await _lutadorRepository.DeleteLutador(id);
        }
        public bool LutadorExists(int id)
        { 
            bool existe = _lutadorRepository.LutadorExists(id);

            return existe;
        }

    }
}
