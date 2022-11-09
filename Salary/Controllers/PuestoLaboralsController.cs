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
    public class PuestoLaboralsController : Controller
    {
        private readonly SalaryDiagContext _context;

        public PuestoLaboralsController(SalaryDiagContext context)
        {
            _context = context;
        }

        // GET: PuestoLaborals
        public async Task<IActionResult> Index()
        {
            return View(await _context.PuestoLaborals.ToListAsync());
        }

        // GET: PuestoLaborals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var puestoLaboral = await _context.PuestoLaborals
                .FirstOrDefaultAsync(m => m.IdPuesto == id);
            if (puestoLaboral == null)
            {
                return NotFound();
            }

            return View(puestoLaboral);
        }

        // GET: PuestoLaborals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PuestoLaborals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPuesto,Puesto")] PuestoLaboral puestoLaboral)
        {
            if (ModelState.IsValid)
            {
                _context.Add(puestoLaboral);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(puestoLaboral);
        }

        // GET: PuestoLaborals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var puestoLaboral = await _context.PuestoLaborals.FindAsync(id);
            if (puestoLaboral == null)
            {
                return NotFound();
            }
            return View(puestoLaboral);
        }

        // POST: PuestoLaborals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPuesto,Puesto")] PuestoLaboral puestoLaboral)
        {
            if (id != puestoLaboral.IdPuesto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(puestoLaboral);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PuestoLaboralExists(puestoLaboral.IdPuesto))
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
            return View(puestoLaboral);
        }

        // GET: PuestoLaborals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var puestoLaboral = await _context.PuestoLaborals
                .FirstOrDefaultAsync(m => m.IdPuesto == id);
            if (puestoLaboral == null)
            {
                return NotFound();
            }

            return View(puestoLaboral);
        }

        // POST: PuestoLaborals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var puestoLaboral = await _context.PuestoLaborals.FindAsync(id);
            _context.PuestoLaborals.Remove(puestoLaboral);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PuestoLaboralExists(int id)
        {
            return _context.PuestoLaborals.Any(e => e.IdPuesto == id);
        }
    }
}
