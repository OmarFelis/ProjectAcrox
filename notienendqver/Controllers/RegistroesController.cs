using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using notienendqver.Models;

namespace notienendqver.Controllers
{
    public class RegistroesController : Controller
    {
        private readonly AcroxOgContext _context;

        public RegistroesController(AcroxOgContext context)
        {
            _context = context;
        }

        // GET: Registroes
        public async Task<IActionResult> Index()
        {
            var acroxOgContext = _context.Registros.Include(r => r.CodViviendaNavigation);
            return View(await acroxOgContext.ToListAsync());
        }

        // GET: Registroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registro = await _context.Registros
                .Include(r => r.CodViviendaNavigation)
                .FirstOrDefaultAsync(m => m.CodRegistro == id);
            if (registro == null)
            {
                return NotFound();
            }

            return View(registro);
        }

        // GET: Registroes/Create
        public IActionResult Create()
        {
            ViewData["CodVivienda"] = new SelectList(_context.Vivienda, "CodVivienda", "DirVivienda");
            return View();
        }

        // POST: Registroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodRegistro,FechRegistro,DescrpRegistro,TipoRegistro,CodVivienda,FechaCreacion")] Registro registro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodVivienda"] = new SelectList(_context.Vivienda, "CodVivienda", "DirVivienda", registro.CodVivienda);
            return View(registro);
        }

        // GET: Registroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registro = await _context.Registros.FindAsync(id);
            if (registro == null)
            {
                return NotFound();
            }
            ViewData["CodVivienda"] = new SelectList(_context.Vivienda, "CodVivienda", "DirVivienda", registro.CodVivienda);
            return View(registro);
        }

        // POST: Registroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodRegistro,FechRegistro,DescrpRegistro,TipoRegistro,CodVivienda,FechaCreacion")] Registro registro)
        {
            if (id != registro.CodRegistro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistroExists(registro.CodRegistro))
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
            ViewData["CodVivienda"] = new SelectList(_context.Vivienda, "CodVivienda", "DirVivienda", registro.CodVivienda);
            return View(registro);
        }

        // GET: Registroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registro = await _context.Registros
                .Include(r => r.CodViviendaNavigation)
                .FirstOrDefaultAsync(m => m.CodRegistro == id);
            if (registro == null)
            {
                return NotFound();
            }

            return View(registro);
        }

        // POST: Registroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registro = await _context.Registros.FindAsync(id);
            if (registro != null)
            {
                _context.Registros.Remove(registro);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistroExists(int id)
        {
            return _context.Registros.Any(e => e.CodRegistro == id);
        }
    }
}
