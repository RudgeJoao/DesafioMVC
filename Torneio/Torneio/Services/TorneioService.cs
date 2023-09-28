using Torneio.Data;
using Torneio.Models;
using Torneio.Repositories;

namespace Torneio.Services
{
    public class TorneioService : ITorneioService
    {
        private readonly ITorneioRepository? _torneioRepository;

        public TorneioService(ITorneioRepository torneioRepository)
        {
            _torneioRepository = torneioRepository;
        }
        public async Task<List<Lutador>> ListarLutadoresAsync() 
        {
            return await _torneioRepository.ListarLutadoresAsync();
        }
    }


}
