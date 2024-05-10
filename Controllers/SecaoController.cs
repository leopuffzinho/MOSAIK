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
    public class SecaoController : Controller
    {
        private readonly Contexto _context;

        public SecaoController(Contexto context)
        {
            _context = context;
        }

        // GET: Secao
        public async Task<IActionResult> Index(string pesquisa)
        {
            if (pesquisa == null)
            {
                return _context.Secao != null ?
                          View(await _context.Secao.ToListAsync()) :
                          Problem("Entity set 'Contexto.Secao'  is null.");
            }
            else
            {
                var secao =
                    _context.Secao
                    .Where(x => x.NomeSecao.Contains(pesquisa))
                    .OrderBy(x => x.NomeSecao);

                return View(secao);
            }
        }

        // GET: Secao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Secao == null)
            {
                return NotFound();
            }

            var secao = await _context.Secao
                .FirstOrDefaultAsync(m => m.SecaoId == id);
            if (secao == null)
            {
                return NotFound();
            }

            return View(secao);
        }

        // GET: Secao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Secao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SecaoId,NomeSecao")] Secao secao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(secao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(secao);
        }

        // GET: Secao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Secao == null)
            {
                return NotFound();
            }

            var secao = await _context.Secao.FindAsync(id);
            if (secao == null)
            {
                return NotFound();
            }
            return View(secao);
        }

        // POST: Secao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SecaoId,NomeSecao")] Secao secao)
        {
            if (id != secao.SecaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(secao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SecaoExists(secao.SecaoId))
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
            return View(secao);
        }

        // GET: Secao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Secao == null)
            {
                return NotFound();
            }

            var secao = await _context.Secao
                .FirstOrDefaultAsync(m => m.SecaoId == id);
            if (secao == null)
            {
                return NotFound();
            }

            return View(secao);
        }

        // POST: Secao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Secao == null)
            {
                return Problem("Entity set 'Contexto.Secao'  is null.");
            }
            var secao = await _context.Secao.FindAsync(id);
            if (secao != null)
            {
                _context.Secao.Remove(secao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SecaoExists(int id)
        {
          return (_context.Secao?.Any(e => e.SecaoId == id)).GetValueOrDefault();
        }
    }
}
