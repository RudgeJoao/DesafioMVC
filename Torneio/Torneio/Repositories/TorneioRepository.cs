using Torneio.Data;

namespace Torneio.Repositories
{
    public class TorneioRepository : ITorneioRepository
    {
        private readonly OracleDbContext _context;

        public TorneioRepository(OracleDbContext context) 
        {
            _context = context;
        }


    }
}
