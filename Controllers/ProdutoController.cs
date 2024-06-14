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
    public class ProdutoController : Controller
    {
        private readonly Contexto _context;

        public ProdutoController(Contexto context)
        {
            _context = context;
        }

        // GET: Produto
        public async Task<IActionResult> Index(string pesquisa)
        {
            if (pesquisa == null)
            {
                return _context.Produto != null ?
                          View(await _context.Produto
                          .Include(x => x.Marca)
                          .Include(x => x.Secao)
                          .Include(x => x.Tamanho)
                          .Include(x => x.TipoProduto).ToListAsync()) :
                          Problem("Entity set 'Contexto.Produto'  is null.");
            }
            else
            {
                var produto =
                    _context.Produto
                    .Include(x => x.Marca)
                    .Include(x => x.Secao)
                    .Include(x => x.Tamanho)
                    .Include(x => x.TipoProduto)
                    .Where(x => x.NomeProduto.Contains(pesquisa) || x.Marca.NomeMarca.Contains(pesquisa) || x.Secao.NomeSecao.Contains(pesquisa) || x.Tamanho.NomeTamanho.Contains(pesquisa) || x.TipoProduto.NomeTipoProduto.Contains(pesquisa))
                    .OrderBy(x => x.NomeProduto);

                return View(produto);
            }
        }

        // GET: Produto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Produto == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto
                .Include(p => p.Marca)
                .Include(p => p.Secao)
                .Include(p => p.Tamanho)
                .Include(p => p.TipoProduto)
                .FirstOrDefaultAsync(m => m.ProdutoId == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: Produto/Create
        public IActionResult Create()
        {
            ViewData["MarcaId"] = new SelectList(_context.Marca, "MarcaId", "NomeMarca");
            ViewData["SecaoId"] = new SelectList(_context.Secao, "SecaoId", "NomeSecao");
            ViewData["TamanhoId"] = new SelectList(_context.Tamanho, "TamanhoId", "NomeTamanho");
            ViewData["TipoProdutoId"] = new SelectList(_context.TipoProduto, "TipoProdutoId", "NomeTipoProduto");
            return View();
        }

        // POST: Produto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProdutoId,NomeProduto,DescricaoProduto,TipoProdutoId,PrecoProduto,QtdEstoque,MarcaId,SecaoId,TamanhoId, FotoProduto")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MarcaId"] = new SelectList(_context.Marca, "MarcaId", "NomeMarca", produto.MarcaId);
            ViewData["SecaoId"] = new SelectList(_context.Secao, "SecaoId", "NomeSecao", produto.SecaoId);
            ViewData["TamanhoId"] = new SelectList(_context.Tamanho, "TamanhoId", "NomeTamanho", produto.TamanhoId);
            ViewData["TipoProdutoId"] = new SelectList(_context.TipoProduto, "TipoProdutoId", "NomeTipoProduto", produto.TipoProdutoId);
            return View(produto);
        }

        // GET: Produto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Produto == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            ViewData["MarcaId"] = new SelectList(_context.Marca, "MarcaId", "NomeMarca", produto.MarcaId);
            ViewData["SecaoId"] = new SelectList(_context.Secao, "SecaoId", "NomeSecao", produto.SecaoId);
            ViewData["TamanhoId"] = new SelectList(_context.Tamanho, "TamanhoId", "NomeTamanho", produto.TamanhoId);
            ViewData["TipoProdutoId"] = new SelectList(_context.TipoProduto, "TipoProdutoId", "NomeTipoProduto", produto.TipoProdutoId);
            return View(produto);
        }

        // POST: Produto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProdutoId,NomeProduto,DescricaoProduto,TipoProdutoId,PrecoProduto,QtdEstoque,MarcaId,SecaoId,TamanhoId, FotoProduto")] Produto produto)
        {
            if (id != produto.ProdutoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.ProdutoId))
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
            ViewData["MarcaId"] = new SelectList(_context.Marca, "MarcaId", "NomeMarca", produto.MarcaId);
            ViewData["SecaoId"] = new SelectList(_context.Secao, "SecaoId", "NomeSecao", produto.SecaoId);
            ViewData["TamanhoId"] = new SelectList(_context.Tamanho, "TamanhoId", "NomeTamanho", produto.TamanhoId);
            ViewData["TipoProdutoId"] = new SelectList(_context.TipoProduto, "TipoProdutoId", "NomeTipoProduto", produto.TipoProdutoId);
            return View(produto);
        }

        // GET: Produto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Produto == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto
                .Include(p => p.Marca)
                .Include(p => p.Secao)
                .Include(p => p.Tamanho)
                .Include(p => p.TipoProduto)
                .FirstOrDefaultAsync(m => m.ProdutoId == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Produto == null)
            {
                return Problem("Entity set 'Contexto.Produto'  is null.");
            }
            var produto = await _context.Produto.FindAsync(id);
            if (produto != null)
            {
                _context.Produto.Remove(produto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
          return (_context.Produto?.Any(e => e.ProdutoId == id)).GetValueOrDefault();
        }
    }
}
