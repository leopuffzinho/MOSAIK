using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MOSAIK.Models;

namespace MOSAIK.Controllers
{
    public class TamanhoController : Controller
    {
        private readonly Contexto _context;

        public TamanhoController(Contexto context)
        {
            _context = context;
        }

        // GET: Tamanho
        public async Task<IActionResult> Index(string pesquisa)
        {
            if (pesquisa == null)
            {
                return _context.Tamanho != null ?
                          View(await _context.Tamanho.ToListAsync()) :
                          Problem("Entity set 'Contexto.Tamanho'  is null.");
            }
            else
            {
                var tamanho =
                    _context.Tamanho
                    .Where(x => x.NomeTamanho.Contains(pesquisa))
                    .OrderBy(x => x.NomeTamanho);

                return View(tamanho);
            }
        }

        // GET: Tamanho/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tamanho == null)
            {
                return NotFound();
            }

            var tamanho = await _context.Tamanho
                .FirstOrDefaultAsync(m => m.TamanhoId == id);
            if (tamanho == null)
            {
                return NotFound();
            }

            return View(tamanho);
        }

        // GET: Tamanho/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tamanho/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TamanhoId,NomeTamanho")] Tamanho tamanho)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tamanho);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tamanho);
        }

        // GET: Tamanho/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tamanho == null)
            {
                return NotFound();
            }

            var tamanho = await _context.Tamanho.FindAsync(id);
            if (tamanho == null)
            {
                return NotFound();
            }
            return View(tamanho);
        }

        // POST: Tamanho/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TamanhoId,NomeTamanho")] Tamanho tamanho)
        {
            if (id != tamanho.TamanhoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tamanho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TamanhoExists(tamanho.TamanhoId))
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
            return View(tamanho);
        }

        // GET: Tamanho/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tamanho == null)
            {
                return NotFound();
            }

            var tamanho = await _context.Tamanho
                .FirstOrDefaultAsync(m => m.TamanhoId == id);
            if (tamanho == null)
            {
                return NotFound();
            }

            return View(tamanho);
        }

        // POST: Tamanho/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tamanho == null)
            {
                return Problem("Entity set 'Contexto.Tamanho'  is null.");
            }
            var tamanho = await _context.Tamanho.FindAsync(id);
            if (tamanho != null)
            {
                _context.Tamanho.Remove(tamanho);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TamanhoExists(int id)
        {
          return (_context.Tamanho?.Any(e => e.TamanhoId == id)).GetValueOrDefault();
        }
    }
}
