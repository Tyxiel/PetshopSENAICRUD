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
    public class VeterinarioController : Controller
    {
        private readonly PetshopSENAIDBContext _context;

        public VeterinarioController(PetshopSENAIDBContext context)
        {
            _context = context;
        }

        // GET: Veterinario
        public async Task<IActionResult> Index()
        {
              return _context.Veterinarios != null ? 
                          View(await _context.Veterinarios.ToListAsync()) :
                          Problem("Entity set 'PetshopSENAIDBContext.Veterinarios'  is null.");
        }

        // GET: Veterinario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Veterinarios == null)
            {
                return NotFound();
            }

            var veterinario = await _context.Veterinarios
                .FirstOrDefaultAsync(m => m.IdVeterinario == id);
            if (veterinario == null)
            {
                return NotFound();
            }

            return View(veterinario);
        }

        // GET: Veterinario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Veterinario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVeterinario,Nome,Crmv")] Veterinario veterinario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(veterinario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(veterinario);
        }

        // GET: Veterinario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Veterinarios == null)
            {
                return NotFound();
            }

            var veterinario = await _context.Veterinarios.FindAsync(id);
            if (veterinario == null)
            {
                return NotFound();
            }
            return View(veterinario);
        }

        // POST: Veterinario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVeterinario,Nome,Crmv")] Veterinario veterinario)
        {
            if (id != veterinario.IdVeterinario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(veterinario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VeterinarioExists(veterinario.IdVeterinario))
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
            return View(veterinario);
        }

        // GET: Veterinario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Veterinarios == null)
            {
                return NotFound();
            }

            var veterinario = await _context.Veterinarios
                .FirstOrDefaultAsync(m => m.IdVeterinario == id);
            if (veterinario == null)
            {
                return NotFound();
            }

            return View(veterinario);
        }

        // POST: Veterinario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Veterinarios == null)
            {
                return Problem("Entity set 'PetshopSENAIDBContext.Veterinarios'  is null.");
            }
            var veterinario = await _context.Veterinarios.FindAsync(id);
            if (veterinario != null)
            {
                _context.Veterinarios.Remove(veterinario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VeterinarioExists(int id)
        {
          return (_context.Veterinarios?.Any(e => e.IdVeterinario == id)).GetValueOrDefault();
        }
    }
}
