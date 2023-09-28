using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Torneio.Data;
using Torneio.Models;
using Torneio.Services;

namespace Torneio.Controllers
{
    public class LutadoresController : Controller
    {
        private readonly OracleDbContext _context;
        private readonly ITorneioService _torneioService;

        public LutadoresController(OracleDbContext context, ITorneioService torneioService)
        {
            _context = context;
            _torneioService = torneioService;
        }

        // GET: Lutadores
        public async Task<IActionResult> Index()
        {
            var query = await _torneioService.GetLutadoresAsync();
            return View(query);
        }

        // GET: Lutadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            var lutador = await _torneioService.GetLutadorAsync(id);

            return View(lutador);
        }

        // GET: Lutadores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lutadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Idade,ArtesMarciais,TotalLutas,Derrotas,Vitorias")] Lutador lutador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lutador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lutador);
        }

        // GET: Lutadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Lutadores == null)
            {
                return NotFound();
            }

            var lutador = await _context.Lutadores.FindAsync(id);
            if (lutador == null)
            {
                return NotFound();
            }
            return View(lutador);
        }

        // POST: Lutadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Idade,ArtesMarciais,TotalLutas,Derrotas,Vitorias")] Lutador lutador)
        {
            if (id != lutador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lutador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LutadorExists(lutador.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(lutador);
        }

        // GET: Lutadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Lutadores == null)
            {
                return NotFound();
            }

            var lutador = await _context.Lutadores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lutador == null)
            {
                return NotFound();
            }

            return View(lutador);
        }

        // POST: Lutadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Lutadores == null)
            {
                return Problem("Entity set 'OracleDbContext.Lutador'  is null.");
            }
            var lutador = await _context.Lutadores.FindAsync(id);
            if (lutador != null)
            {
                _context.Lutadores.Remove(lutador);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LutadorExists(int id)
        {
            return (_context.Lutadores?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
