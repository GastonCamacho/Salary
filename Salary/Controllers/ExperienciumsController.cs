using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Salary.Models;

namespace Salary.Controllers
{
    public class ExperienciumsController : Controller
    {
        private readonly SalaryDiagContext _context;

        public ExperienciumsController(SalaryDiagContext context)
        {
            _context = context;
        }

        // GET: Experienciums
        public async Task<IActionResult> Index()
        {
            return View(await _context.Experiencia.ToListAsync());
        }

        // GET: Experienciums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experiencium = await _context.Experiencia
                .FirstOrDefaultAsync(m => m.IdExperiencia == id);
            if (experiencium == null)
            {
                return NotFound();
            }

            return View(experiencium);
        }

        // GET: Experienciums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Experienciums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdExperiencia,Experiencia")] Experiencium experiencium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(experiencium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(experiencium);
        }

        // GET: Experienciums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experiencium = await _context.Experiencia.FindAsync(id);
            if (experiencium == null)
            {
                return NotFound();
            }
            return View(experiencium);
        }

        // POST: Experienciums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdExperiencia,Experiencia")] Experiencium experiencium)
        {
            if (id != experiencium.IdExperiencia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(experiencium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExperienciumExists(experiencium.IdExperiencia))
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
            return View(experiencium);
        }

        // GET: Experienciums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experiencium = await _context.Experiencia
                .FirstOrDefaultAsync(m => m.IdExperiencia == id);
            if (experiencium == null)
            {
                return NotFound();
            }

            return View(experiencium);
        }

        // POST: Experienciums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var experiencium = await _context.Experiencia.FindAsync(id);
            _context.Experiencia.Remove(experiencium);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExperienciumExists(int id)
        {
            return _context.Experiencia.Any(e => e.IdExperiencia == id);
        }
    }
}
