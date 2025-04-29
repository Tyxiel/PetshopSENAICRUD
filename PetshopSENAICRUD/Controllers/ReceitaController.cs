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
    public class ReceitaController : Controller
    {
        private readonly PetshopSENAIDBContext _context;

        public ReceitaController(PetshopSENAIDBContext context)
        {
            _context = context;
        }

        // GET: Receita
        public async Task<IActionResult> Index()
        {
            var petshopSENAIDBContext = _context.Receita.Include(r => r.IdConsultaNavigation);
            return View(await petshopSENAIDBContext.ToListAsync());
        }

        // GET: Receita/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Receita == null)
            {
                return NotFound();
            }

            var receitum = await _context.Receita
                .Include(r => r.IdConsultaNavigation)
                .FirstOrDefaultAsync(m => m.IdReceita == id);
            if (receitum == null)
            {
                return NotFound();
            }

            return View(receitum);
        }

        // GET: Receita/Create
        public IActionResult Create()
        {
            ViewData["IdConsulta"] = new SelectList(_context.Consulta, "IdConsulta", "IdConsulta");
            return View();
        }

        // POST: Receita/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdReceita,Descricao,IdConsulta")] Receitum receitum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(receitum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdConsulta"] = new SelectList(_context.Consulta, "IdConsulta", "IdConsulta", receitum.IdConsulta);
            return View(receitum);
        }

        // GET: Receita/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Receita == null)
            {
                return NotFound();
            }

            var receitum = await _context.Receita.FindAsync(id);
            if (receitum == null)
            {
                return NotFound();
            }
            ViewData["IdConsulta"] = new SelectList(_context.Consulta, "IdConsulta", "IdConsulta", receitum.IdConsulta);
            return View(receitum);
        }

        // POST: Receita/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdReceita,Descricao,IdConsulta")] Receitum receitum)
        {
            if (id != receitum.IdReceita)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(receitum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReceitumExists(receitum.IdReceita))
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
            ViewData["IdConsulta"] = new SelectList(_context.Consulta, "IdConsulta", "IdConsulta", receitum.IdConsulta);
            return View(receitum);
        }

        // GET: Receita/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Receita == null)
            {
                return NotFound();
            }

            var receitum = await _context.Receita
                .Include(r => r.IdConsultaNavigation)
                .FirstOrDefaultAsync(m => m.IdReceita == id);
            if (receitum == null)
            {
                return NotFound();
            }

            return View(receitum);
        }

        // POST: Receita/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Receita == null)
            {
                return Problem("Entity set 'PetshopSENAIDBContext.Receita'  is null.");
            }
            var receitum = await _context.Receita.FindAsync(id);
            if (receitum != null)
            {
                _context.Receita.Remove(receitum);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReceitumExists(int id)
        {
          return (_context.Receita?.Any(e => e.IdReceita == id)).GetValueOrDefault();
        }
    }
}
