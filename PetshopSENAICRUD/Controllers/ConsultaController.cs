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
    public class ConsultaController : Controller
    {
        private readonly PetshopSENAIDBContext _context;

        public ConsultaController(PetshopSENAIDBContext context)
        {
            _context = context;
        }

        // GET: Consulta
        public async Task<IActionResult> Index()
        {
            var petshopSENAIDBContext = _context.Consulta.Include(c => c.IdAnimalNavigation).Include(c => c.IdStatusNavigation).Include(c => c.IdVeterinarioNavigation);
            return View(await petshopSENAIDBContext.ToListAsync());
        }

        // GET: Consulta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Consulta == null)
            {
                return NotFound();
            }

            var consultum = await _context.Consulta
                .Include(c => c.IdAnimalNavigation)
                .Include(c => c.IdStatusNavigation)
                .Include(c => c.IdVeterinarioNavigation)
                .FirstOrDefaultAsync(m => m.IdConsulta == id);
            if (consultum == null)
            {
                return NotFound();
            }

            return View(consultum);
        }

        // GET: Consulta/Create
        public IActionResult Create()
        {
            ViewData["IdAnimal"] = new SelectList(_context.Animals, "IdAnimal", "Especie");
            ViewData["IdStatus"] = new SelectList(_context.StatusConsulta, "IdStatus", "Descricao");
            ViewData["IdVeterinario"] = new SelectList(_context.Veterinarios, "IdVeterinario", "Crmv");
            return View();
        }

        // POST: Consulta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdConsulta,Data,IdStatus,IdAnimal,IdVeterinario")] Consultum consultum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consultum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAnimal"] = new SelectList(_context.Animals, "IdAnimal", "Especie", consultum.IdAnimal);
            ViewData["IdStatus"] = new SelectList(_context.StatusConsulta, "IdStatus", "Descricao", consultum.IdStatus);
            ViewData["IdVeterinario"] = new SelectList(_context.Veterinarios, "IdVeterinario", "Crmv", consultum.IdVeterinario);
            return View(consultum);
        }

        // GET: Consulta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Consulta == null)
            {
                return NotFound();
            }

            var consultum = await _context.Consulta.FindAsync(id);
            if (consultum == null)
            {
                return NotFound();
            }
            ViewData["IdAnimal"] = new SelectList(_context.Animals, "IdAnimal", "Especie", consultum.IdAnimal);
            ViewData["IdStatus"] = new SelectList(_context.StatusConsulta, "IdStatus", "Descricao", consultum.IdStatus);
            ViewData["IdVeterinario"] = new SelectList(_context.Veterinarios, "IdVeterinario", "Crmv", consultum.IdVeterinario);
            return View(consultum);
        }

        // POST: Consulta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdConsulta,Data,IdStatus,IdAnimal,IdVeterinario")] Consultum consultum)
        {
            if (id != consultum.IdConsulta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consultum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultumExists(consultum.IdConsulta))
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
            ViewData["IdAnimal"] = new SelectList(_context.Animals, "IdAnimal", "Especie", consultum.IdAnimal);
            ViewData["IdStatus"] = new SelectList(_context.StatusConsulta, "IdStatus", "Descricao", consultum.IdStatus);
            ViewData["IdVeterinario"] = new SelectList(_context.Veterinarios, "IdVeterinario", "Crmv", consultum.IdVeterinario);
            return View(consultum);
        }

        // GET: Consulta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Consulta == null)
            {
                return NotFound();
            }

            var consultum = await _context.Consulta
                .Include(c => c.IdAnimalNavigation)
                .Include(c => c.IdStatusNavigation)
                .Include(c => c.IdVeterinarioNavigation)
                .FirstOrDefaultAsync(m => m.IdConsulta == id);
            if (consultum == null)
            {
                return NotFound();
            }

            return View(consultum);
        }

        // POST: Consulta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Consulta == null)
            {
                return Problem("Entity set 'PetshopSENAIDBContext.Consulta'  is null.");
            }
            var consultum = await _context.Consulta.FindAsync(id);
            if (consultum != null)
            {
                _context.Consulta.Remove(consultum);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsultumExists(int id)
        {
          return (_context.Consulta?.Any(e => e.IdConsulta == id)).GetValueOrDefault();
        }
    }
}
