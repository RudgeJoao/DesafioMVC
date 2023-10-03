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
        private readonly ITorneioService _torneioService;

        public LutadoresController(ITorneioService torneioService)
        {
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
        public async Task<IActionResult> Create(Lutador lutador)
        {
            if (ModelState.IsValid)
            {
                await _torneioService.CreateLutador(lutador);
                return RedirectToAction(nameof(Index));
            }
            return View(lutador);
        }

        // GET: Lutadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _torneioService.GetLutadoresAsync() == null)
            {
                return NotFound();
            }

            var lutador = await _torneioService.GetLutadorAsync(id);
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
        public async Task<IActionResult> Edit(int id,Lutador lutador)
        {
            if (id != lutador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _torneioService.UpdateLutador(id, lutador);
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
            if (id == null)
            {
                return NotFound();
            }

            var lutador = await _torneioService.GetLutadorAsync(id);
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
            if (_torneioService.GetLutadoresAsync() == null)
            {
                return Problem("Entity set 'OracleDbContext.Lutador'  is null.");
            }
            
            _torneioService.DeleteLutador(id);
            return RedirectToAction(nameof(Index));
        }

        private bool LutadorExists(int id)
        {
            bool existe = _torneioService.LutadorExists(id);

            return existe;
        }
    }
}
