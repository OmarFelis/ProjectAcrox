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
    public class ContratoesController : Controller
    {
        private readonly AcroxOgContext _context;

        public ContratoesController(AcroxOgContext context)
        {
            _context = context;
        }

        // GET: Contratoes
        public async Task<IActionResult> Index()
        {
            var acroxOgContext = _context.Contratos.Include(c => c.CodViviendaNavigation);
            return View(await acroxOgContext.ToListAsync());
        }

        // GET: Contratoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contrato = await _context.Contratos
                .Include(c => c.CodViviendaNavigation)
                .FirstOrDefaultAsync(m => m.CodContrato == id);
            if (contrato == null)
            {
                return NotFound();
            }

            return View(contrato);
        }

        // GET: Contratoes/Create
        public IActionResult Create()
        {
            ViewData["CodVivienda"] = new SelectList(_context.Vivienda, "CodVivienda","DirVivienda");
            return View();
        }

        // POST: Contratoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodContrato,CodVivienda,TipoContrato,FechaCreacion")] Contrato contrato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contrato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodVivienda"] = new SelectList(_context.Vivienda, "CodVivienda", "CodVivienda", contrato.CodVivienda);
            return View(contrato);
        }

        // GET: Contratoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contrato = await _context.Contratos.FindAsync(id);
            if (contrato == null)
            {
                return NotFound();
            }
            ViewData["CodVivienda"] = new SelectList(_context.Vivienda, "CodVivienda", "DirVivienda", contrato.CodVivienda);
            return View(contrato);
        }

        // POST: Contratoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodContrato,CodVivienda,TipoContrato,FechaCreacion")] Contrato contrato)
        {
            if (id != contrato.CodContrato)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contrato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContratoExists(contrato.CodContrato))
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
            ViewData["CodVivienda"] = new SelectList(_context.Vivienda, "CodVivienda", "CodVivienda", contrato.CodVivienda);
            return View(contrato);
        }

        // GET: Contratoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contrato = await _context.Contratos
                .Include(c => c.CodViviendaNavigation)
                .FirstOrDefaultAsync(m => m.CodContrato == id);
            if (contrato == null)
            {
                return NotFound();
            }

            return View(contrato);
        }

        // POST: Contratoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contrato = await _context.Contratos.FindAsync(id);
            if (contrato != null)
            {
                _context.Contratos.Remove(contrato);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContratoExists(int id)
        {
            return _context.Contratos.Any(e => e.CodContrato == id);
        }
    }
}
