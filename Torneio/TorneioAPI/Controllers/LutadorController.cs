using Microsoft.AspNetCore.Mvc;
using Torneio.Models;
using TorneioAPI.Data;

namespace TorneioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LutadorController : ControllerBase
    {
        private readonly OracleDbContext _DbContext;

        public LutadorController(OracleDbContext dbContext)
        {
            _DbContext = dbContext;
        }   

        [HttpGet]
        public List<Lutador> GetLutadores()
        {       
           return _DbContext.Lutadores.ToList();
        }

        [HttpGet("{id:int}")]
        public Lutador GetLutador(int id) 
        {
            return _DbContext.Lutadores.FirstOrDefault(lutador => lutador.Id == id);
        }

        [HttpPost]
        public IActionResult CreateLutador(Lutador newLutador) 
        {
            if (ModelState.IsValid) // Verifica se o modelo passado é válido
            {
                _DbContext.Lutadores.Add(newLutador);
                _DbContext.SaveChanges();

                return CreatedAtAction("GetLutador", new { id = newLutador.Id }, newLutador);
             
            }
            else 
            { 
                return BadRequest(ModelState);
            }
        }

        [HttpPut]

        public IActionResult UpdateLutador(int id, Lutador updateLutador) 
        {
            var lutador = _DbContext.Lutadores.FirstOrDefault(lutador => lutador.Id == id);
            if (lutador == null) 
            { 
                return NotFound();
            }

            lutador.Nome = updateLutador.Nome;
            lutador.Idade = updateLutador.Idade;
            lutador.ArtesMarciais = updateLutador.ArtesMarciais;
            lutador.Derrotas = updateLutador.Derrotas;
            lutador.Vitorias = updateLutador.Vitorias;
            lutador.TotalLutas = updateLutador.TotalLutas;

            _DbContext.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteLutador(int id) 
        {
            var lutador = _DbContext.Lutadores.FirstOrDefault(lutador => lutador.Id == id);
            if (lutador == null)
            {
                return NotFound();
            }

            _DbContext.Lutadores.Remove(lutador);
            _DbContext.SaveChanges();

            return NoContent();
        }

    }
}
