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
    public class DetalleUsuariosController : Controller
    {
        private readonly SalaryDiagContext _context;

        public DetalleUsuariosController(SalaryDiagContext context)
        {
            _context = context;
        }

        // GET: DetalleUsuarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.DetalleUsuarios.ToListAsync());
        }

        // GET: DetalleUsuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleUsuario = await _context.DetalleUsuarios
                .FirstOrDefaultAsync(m => m.IdDetalle == id);
            if (detalleUsuario == null)
            {
                return NotFound();
            }

            return View(detalleUsuario);
        }

        // GET: DetalleUsuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DetalleUsuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDetalle,FechaNacimiento,Genero,Telefono,EstadoCivil,Hijos,IdUsuario,IdCiudad,IdEmpleo,IdTipoUsuario")] DetalleUsuario detalleUsuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(detalleUsuario);
        }

        // GET: DetalleUsuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleUsuario = await _context.DetalleUsuarios.FindAsync(id);
            if (detalleUsuario == null)
            {
                return NotFound();
            }
            return View(detalleUsuario);
        }

        // POST: DetalleUsuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDetalle,FechaNacimiento,Genero,Telefono,EstadoCivil,Hijos,IdUsuario,IdCiudad,IdEmpleo,IdTipoUsuario")] DetalleUsuario detalleUsuario)
        {
            if (id != detalleUsuario.IdDetalle)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleUsuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleUsuarioExists(detalleUsuario.IdDetalle))
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
            return View(detalleUsuario);
        }

        // GET: DetalleUsuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleUsuario = await _context.DetalleUsuarios
                .FirstOrDefaultAsync(m => m.IdDetalle == id);
            if (detalleUsuario == null)
            {
                return NotFound();
            }

            return View(detalleUsuario);
        }

        // POST: DetalleUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detalleUsuario = await _context.DetalleUsuarios.FindAsync(id);
            _context.DetalleUsuarios.Remove(detalleUsuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleUsuarioExists(int id)
        {
            return _context.DetalleUsuarios.Any(e => e.IdDetalle == id);
        }
    }
}
