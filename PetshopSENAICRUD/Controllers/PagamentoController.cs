using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetshopSENAICRUD.Models;

namespace PetshopSENAICRUD.Controllers
{
    public class PagamentoController : Controller
    {
        private readonly PetshopSENAIDBContext _context;

        public PagamentoController(PetshopSENAIDBContext context)
        {
            _context = context;
        }

        // GET: Pagamento
        public async Task<IActionResult> Index()
        {
            var petshopSENAIDBContext = _context.Pagamentos.Include(p => p.IdConsultaNavigation).Include(p => p.IdFormaDePagamentoNavigation);
            return View(await petshopSENAIDBContext.ToListAsync());
        }

        // GET: Pagamento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pagamentos == null)
            {
                return NotFound();
            }

            var pagamento = await _context.Pagamentos
                .Include(p => p.IdConsultaNavigation)
                .Include(p => p.IdFormaDePagamentoNavigation)
                .FirstOrDefaultAsync(m => m.IdPagamento == id);
            if (pagamento == null)
            {
                return NotFound();
            }

            return View(pagamento);
        }

        // GET: Pagamento/Create
        public IActionResult Create()
        {
            ViewData["IdConsulta"] = new SelectList(_context.Consulta, "IdConsulta", "IdConsulta");
            ViewData["IdFormaDePagamento"] = new SelectList(_context.FormaDePagamentos, "IdFormaDePagamento", "Descricao");
            return View();
        }

        // POST: Pagamento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPagamento,Valor,IdFormaDePagamento,IdConsulta")] Pagamento pagamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pagamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdConsulta"] = new SelectList(_context.Consulta, "IdConsulta", "IdConsulta", pagamento.IdConsulta);
            ViewData["IdFormaDePagamento"] = new SelectList(_context.FormaDePagamentos, "IdFormaDePagamento", "Descricao", pagamento.IdFormaDePagamento);
            return View(pagamento);
        }

        // GET: Pagamento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pagamentos == null)
            {
                return NotFound();
            }

            var pagamento = await _context.Pagamentos.FindAsync(id);
            if (pagamento == null)
            {
                return NotFound();
            }
            ViewData["IdConsulta"] = new SelectList(_context.Consulta, "IdConsulta", "IdConsulta", pagamento.IdConsulta);
            ViewData["IdFormaDePagamento"] = new SelectList(_context.FormaDePagamentos, "IdFormaDePagamento", "Descricao", pagamento.IdFormaDePagamento);
            return View(pagamento);
        }

        // POST: Pagamento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPagamento,Valor,IdFormaDePagamento,IdConsulta")] Pagamento pagamento)
        {
            if (id != pagamento.IdPagamento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pagamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PagamentoExists(pagamento.IdPagamento))
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
            ViewData["IdConsulta"] = new SelectList(_context.Consulta, "IdConsulta", "IdConsulta", pagamento.IdConsulta);
            ViewData["IdFormaDePagamento"] = new SelectList(_context.FormaDePagamentos, "IdFormaDePagamento", "Descricao", pagamento.IdFormaDePagamento);
            return View(pagamento);
        }

        // GET: Pagamento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pagamentos == null)
            {
                return NotFound();
            }

            var pagamento = await _context.Pagamentos
                .Include(p => p.IdConsultaNavigation)
                .Include(p => p.IdFormaDePagamentoNavigation)
                .FirstOrDefaultAsync(m => m.IdPagamento == id);
            if (pagamento == null)
            {
                return NotFound();
            }

            return View(pagamento);
        }

        // POST: Pagamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pagamentos == null)
            {
                return Problem("Entity set 'PetshopSENAIDBContext.Pagamentos'  is null.");
            }
            var pagamento = await _context.Pagamentos.FindAsync(id);
            if (pagamento != null)
            {
                _context.Pagamentos.Remove(pagamento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PagamentoExists(int id)
        {
          return (_context.Pagamentos?.Any(e => e.IdPagamento == id)).GetValueOrDefault();
        }
    }
}
