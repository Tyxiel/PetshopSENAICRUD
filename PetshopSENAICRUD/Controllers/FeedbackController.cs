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
    public class FeedbackController : Controller
    {
        private readonly PetshopSENAIDBContext _context;

        public FeedbackController(PetshopSENAIDBContext context)
        {
            _context = context;
        }

        // GET: Feedback
        public async Task<IActionResult> Index()
        {
            var petshopSENAIDBContext = _context.Feedbacks.Include(f => f.IdClienteNavigation).Include(f => f.IdTipoFeedbackNavigation);
            return View(await petshopSENAIDBContext.ToListAsync());
        }

        // GET: Feedback/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Feedbacks == null)
            {
                return NotFound();
            }

            var feedback = await _context.Feedbacks
                .Include(f => f.IdClienteNavigation)
                .Include(f => f.IdTipoFeedbackNavigation)
                .FirstOrDefaultAsync(m => m.IdFeedback == id);
            if (feedback == null)
            {
                return NotFound();
            }

            return View(feedback);
        }

        // GET: Feedback/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "Email");
            ViewData["IdTipoFeedback"] = new SelectList(_context.TipoFeedbacks, "IdTipoFeedback", "Descricao");
            return View();
        }

        // POST: Feedback/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFeedback,Tipo,IdCliente,IdTipoFeedback")] Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                _context.Add(feedback);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "Email", feedback.IdCliente);
            ViewData["IdTipoFeedback"] = new SelectList(_context.TipoFeedbacks, "IdTipoFeedback", "Descricao", feedback.IdTipoFeedback);
            return View(feedback);
        }

        // GET: Feedback/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Feedbacks == null)
            {
                return NotFound();
            }

            var feedback = await _context.Feedbacks.FindAsync(id);
            if (feedback == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "Email", feedback.IdCliente);
            ViewData["IdTipoFeedback"] = new SelectList(_context.TipoFeedbacks, "IdTipoFeedback", "Descricao", feedback.IdTipoFeedback);
            return View(feedback);
        }

        // POST: Feedback/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFeedback,Tipo,IdCliente,IdTipoFeedback")] Feedback feedback)
        {
            if (id != feedback.IdFeedback)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(feedback);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeedbackExists(feedback.IdFeedback))
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
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "Email", feedback.IdCliente);
            ViewData["IdTipoFeedback"] = new SelectList(_context.TipoFeedbacks, "IdTipoFeedback", "Descricao", feedback.IdTipoFeedback);
            return View(feedback);
        }

        // GET: Feedback/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Feedbacks == null)
            {
                return NotFound();
            }

            var feedback = await _context.Feedbacks
                .Include(f => f.IdClienteNavigation)
                .Include(f => f.IdTipoFeedbackNavigation)
                .FirstOrDefaultAsync(m => m.IdFeedback == id);
            if (feedback == null)
            {
                return NotFound();
            }

            return View(feedback);
        }

        // POST: Feedback/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Feedbacks == null)
            {
                return Problem("Entity set 'PetshopSENAIDBContext.Feedbacks'  is null.");
            }
            var feedback = await _context.Feedbacks.FindAsync(id);
            if (feedback != null)
            {
                _context.Feedbacks.Remove(feedback);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeedbackExists(int id)
        {
          return (_context.Feedbacks?.Any(e => e.IdFeedback == id)).GetValueOrDefault();
        }
    }
}
