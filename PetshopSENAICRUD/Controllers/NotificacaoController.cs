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
    public class NotificacaoController : Controller
    {
        private readonly PetshopSENAIDBContext _context;

        public NotificacaoController(PetshopSENAIDBContext context)
        {
            _context = context;
        }

        // GET: Notificacao
        public async Task<IActionResult> Index()
        {
            var petshopSENAIDBContext = _context.Notificacaos.Include(n => n.IdClienteNavigation);
            return View(await petshopSENAIDBContext.ToListAsync());
        }

        // GET: Notificacao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Notificacaos == null)
            {
                return NotFound();
            }

            var notificacao = await _context.Notificacaos
                .Include(n => n.IdClienteNavigation)
                .FirstOrDefaultAsync(m => m.IdNotificacao == id);
            if (notificacao == null)
            {
                return NotFound();
            }

            return View(notificacao);
        }

        // GET: Notificacao/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "Email");
            return View();
        }

        // POST: Notificacao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNotificacao,Tipo,DataEnvio,IdCliente")] Notificacao notificacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notificacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "Email", notificacao.IdCliente);
            return View(notificacao);
        }

        // GET: Notificacao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Notificacaos == null)
            {
                return NotFound();
            }

            var notificacao = await _context.Notificacaos.FindAsync(id);
            if (notificacao == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "Email", notificacao.IdCliente);
            return View(notificacao);
        }

        // POST: Notificacao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNotificacao,Tipo,DataEnvio,IdCliente")] Notificacao notificacao)
        {
            if (id != notificacao.IdNotificacao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notificacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotificacaoExists(notificacao.IdNotificacao))
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
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "Email", notificacao.IdCliente);
            return View(notificacao);
        }

        // GET: Notificacao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Notificacaos == null)
            {
                return NotFound();
            }

            var notificacao = await _context.Notificacaos
                .Include(n => n.IdClienteNavigation)
                .FirstOrDefaultAsync(m => m.IdNotificacao == id);
            if (notificacao == null)
            {
                return NotFound();
            }

            return View(notificacao);
        }

        // POST: Notificacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Notificacaos == null)
            {
                return Problem("Entity set 'PetshopSENAIDBContext.Notificacaos'  is null.");
            }
            var notificacao = await _context.Notificacaos.FindAsync(id);
            if (notificacao != null)
            {
                _context.Notificacaos.Remove(notificacao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotificacaoExists(int id)
        {
          return (_context.Notificacaos?.Any(e => e.IdNotificacao == id)).GetValueOrDefault();
        }
    }
}
