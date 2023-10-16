using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Torneio.Repositories;
using Torneio.Services;

namespace Torneio.Controllers
{
    public class ResultadoTorneioController : Controller
    {
        // GET: ResultadoTorneioController

        private readonly ITorneioService _torneioService;
        private readonly ITorneioRepository _torneioRepository;

        public ResultadoTorneioController(ITorneioService torneioService, ITorneioRepository torneioRepository) 
        {
            _torneioService = torneioService;
            _torneioRepository = torneioRepository;
        }
        public async Task<IActionResult> Index()
        {
            var query = await _torneioService.ResultadoTorneio();
            return View(query);
        }

        public async Task<IActionResult> HistoricoTorneios() 
        {
            var historico = await _torneioRepository.ListarTorneiosAsync();
            return View(historico);
        }
    }
}
