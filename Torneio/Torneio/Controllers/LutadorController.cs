using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Torneio.Data;
using Torneio.Models;

namespace Torneio.Controllers
{
    public class LutadorController : Controller
    {
        private readonly OracleDbContext _context;

        public LutadorController(OracleDbContext context)
        {
            _context = context;
        }

        // GET: Lutador
        public async Task<IActionResult> Index()
        {
              return _context.Lutador != null ? 
                          View(await _context.Lutador.ToListAsync()) :
                          Problem("Entity set 'OracleDbContext.Lutador'  is null.");
        }

        // GET: Lutador/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Lutador == null)
            {
                return NotFound();
            }

            var lutador = await _context.Lutador
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lutador == null)
            {
                return NotFound();
            }

            return View(lutador);
        }

        // GET: Lutador/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lutador/Create
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

        // GET: Lutador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Lutador == null)
            {
                return NotFound();
            }

            var lutador = await _context.Lutador.FindAsync(id);
            if (lutador == null)
            {
                return NotFound();
            }
            return View(lutador);
        }

        // POST: Lutador/Edit/5
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

        // GET: Lutador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Lutador == null)
            {
                return NotFound();
            }

            var lutador = await _context.Lutador
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lutador == null)
            {
                return NotFound();
            }

            return View(lutador);
        }

        // POST: Lutador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Lutador == null)
            {
                return Problem("Entity set 'OracleDbContext.Lutador'  is null.");
            }
            var lutador = await _context.Lutador.FindAsync(id);
            if (lutador != null)
            {
                _context.Lutador.Remove(lutador);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LutadorExists(int id)
        {
          return (_context.Lutador?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
