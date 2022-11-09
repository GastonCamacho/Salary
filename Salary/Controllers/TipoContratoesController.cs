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
    public class TipoContratoesController : Controller
    {
        private readonly SalaryDiagContext _context;

        public TipoContratoesController(SalaryDiagContext context)
        {
            _context = context;
        }

        // GET: TipoContratoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoContratos.ToListAsync());
        }

        // GET: TipoContratoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoContrato = await _context.TipoContratos
                .FirstOrDefaultAsync(m => m.IdContrato == id);
            if (tipoContrato == null)
            {
                return NotFound();
            }

            return View(tipoContrato);
        }

        // GET: TipoContratoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoContratoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdContrato,Contrato")] TipoContrato tipoContrato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoContrato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoContrato);
        }

        // GET: TipoContratoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoContrato = await _context.TipoContratos.FindAsync(id);
            if (tipoContrato == null)
            {
                return NotFound();
            }
            return View(tipoContrato);
        }

        // POST: TipoContratoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdContrato,Contrato")] TipoContrato tipoContrato)
        {
            if (id != tipoContrato.IdContrato)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoContrato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoContratoExists(tipoContrato.IdContrato))
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
            return View(tipoContrato);
        }

        // GET: TipoContratoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoContrato = await _context.TipoContratos
                .FirstOrDefaultAsync(m => m.IdContrato == id);
            if (tipoContrato == null)
            {
                return NotFound();
            }

            return View(tipoContrato);
        }

        // POST: TipoContratoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoContrato = await _context.TipoContratos.FindAsync(id);
            _context.TipoContratos.Remove(tipoContrato);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoContratoExists(int id)
        {
            return _context.TipoContratos.Any(e => e.IdContrato == id);
        }
    }
}
