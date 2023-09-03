using Torneio.Data;
using Torneio.Models;

namespace Torneio.Services
{
    public class TorneioService : ITorneioService
    {
        private readonly OracleDbContext _dbContext;

        public TorneioService(OracleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Lutador> ListarLutadores() 
        {
            return _dbContext.Lutadores.ToList();
        }
    }


}
