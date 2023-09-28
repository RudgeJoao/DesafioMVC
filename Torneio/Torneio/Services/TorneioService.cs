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
            if (id == null || _torneioRepository.GetLutadorAsync(id) == null)
            {
                return NotFound();
            }

            var lutador = await _torneioRepository.GetLutadorAsync(id);

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
    }
}
