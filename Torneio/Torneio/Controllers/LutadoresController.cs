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
        private readonly ILutadorService _lutadorService;

        public LutadoresController(ILutadorService lutadorService)
        {
            _lutadorService = lutadorService;
        }

        // GET: Lutadores
        public async Task<IActionResult> Index()
        {
            var query = await _lutadorService.GetLutadoresAsync();
            return View(query);
        }
        public async Task<IActionResult> PreTorneio()
        {
            var query = await _lutadorService.GetLutadoresAsync();
            return View(query);
        }

        // GET: Lutadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            var lutador = await _lutadorService.GetLutadorAsync(id);

            return View(lutador);
        }

        // GET: Lutadores/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Lutador lutador)
        {
            if (ModelState.IsValid)
            {
                await _lutadorService.CreateLutador(lutador);
                return RedirectToAction(nameof(Index));
            }
            return View(lutador);
        }

        // GET: Lutadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _lutadorService.GetLutadoresAsync() == null)
            {
                return NotFound();
            }

            var lutador = await _lutadorService.GetLutadorAsync(id);
            if (lutador == null)
            {
                return NotFound();
            }
            return View(lutador);
        }

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
                    _lutadorService.UpdateLutador(id, lutador);
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

            var lutador = await _lutadorService.GetLutadorAsync(id);
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
            if (_lutadorService.GetLutadoresAsync() == null)
            {
                return Problem("Entity set 'OracleDbContext.Lutador'  is null.");
            }
            
            _lutadorService.DeleteLutador(id);
            return RedirectToAction(nameof(Index));
        }

        private bool LutadorExists(int id)
        {
            bool existe = _lutadorService.LutadorExists(id);

            return existe;
        }
    }
}
