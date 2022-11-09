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
    public class EmpleosController : Controller
    {
        private readonly SalaryDiagContext _context;

        public EmpleosController(SalaryDiagContext context)
        {
            _context = context;
        }

        // GET: Empleos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Empleos.ToListAsync());
        }

        // GET: Empleos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleo = await _context.Empleos
                .FirstOrDefaultAsync(m => m.IdEmpleo == id);
            if (empleo == null)
            {
                return NotFound();
            }

            return View(empleo);
        }

        // GET: Empleos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Empleos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEmpleo,IdPuesto,Empresa,IdExperiencia,UltimoSueldo,IdCiudad,IdUsuario,IdContrato")] Empleo empleo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empleo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empleo);
        }

        // GET: Empleos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleo = await _context.Empleos.FindAsync(id);
            if (empleo == null)
            {
                return NotFound();
            }
            return View(empleo);
        }

        // POST: Empleos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEmpleo,IdPuesto,Empresa,IdExperiencia,UltimoSueldo,IdCiudad,IdUsuario,IdContrato")] Empleo empleo)
        {
            if (id != empleo.IdEmpleo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleoExists(empleo.IdEmpleo))
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
            return View(empleo);
        }

        // GET: Empleos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleo = await _context.Empleos
                .FirstOrDefaultAsync(m => m.IdEmpleo == id);
            if (empleo == null)
            {
                return NotFound();
            }

            return View(empleo);
        }

        // POST: Empleos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empleo = await _context.Empleos.FindAsync(id);
            _context.Empleos.Remove(empleo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleoExists(int id)
        {
            return _context.Empleos.Any(e => e.IdEmpleo == id);
        }
    }
}
