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
    public class VisitumsController : Controller
    {
        private readonly AcroxOgContext _context;

        public VisitumsController(AcroxOgContext context)
        {
            _context = context;
        }

        // GET: Visitums
        public async Task<IActionResult> Index()
        {
            var acroxOgContext = _context.Visita.Include(v => v.CodBeneficiarioNavigation).Include(v => v.CodViviendaNavigation);
            return View(await acroxOgContext.ToListAsync());
        }

        // GET: Visitums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitum = await _context.Visita
                .Include(v => v.CodBeneficiarioNavigation)
                .Include(v => v.CodViviendaNavigation)
                .FirstOrDefaultAsync(m => m.CodVisita == id);
            if (visitum == null)
            {
                return NotFound();
            }

            return View(visitum);
        }

        // GET: Visitums/Create
        public IActionResult Create()
        {
            ViewData["CodBeneficiario"] = new SelectList(_context.Beneficiarios, "CodBeneficiario", "NombreCBeneficiario");
            ViewData["CodVivienda"] = new SelectList(_context.Vivienda, "CodVivienda", "DirVivienda");
            return View();
        }

        // POST: Visitums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodVisita,FechaVisita,DespVisita,CodBeneficiario,CodVivienda,FechaCreacion")] Visitum visitum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(visitum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodBeneficiario"] = new SelectList(_context.Beneficiarios, "CodBeneficiario", "CodBeneficiario", visitum.CodBeneficiario);
            ViewData["CodVivienda"] = new SelectList(_context.Vivienda, "CodVivienda", "DirVivienda", visitum.CodVivienda);
            return View(visitum);
        }

        // GET: Visitums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitum = await _context.Visita.FindAsync(id);
            if (visitum == null)
            {
                return NotFound();
            }
            ViewData["CodBeneficiario"] = new SelectList(_context.Beneficiarios, "CodBeneficiario", "NombreCBeneficiario", visitum.CodBeneficiario);
            ViewData["CodVivienda"] = new SelectList(_context.Vivienda, "CodVivienda", "DirVivienda", visitum.CodVivienda);
            return View(visitum);
        }

        // POST: Visitums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodVisita,FechaVisita,DespVisita,CodBeneficiario,CodVivienda,FechaCreacion")] Visitum visitum)
        {
            if (id != visitum.CodVisita)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(visitum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisitumExists(visitum.CodVisita))
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
            ViewData["CodBeneficiario"] = new SelectList(_context.Beneficiarios, "CodBeneficiario", "CodBeneficiario", visitum.CodBeneficiario);
            ViewData["CodVivienda"] = new SelectList(_context.Vivienda, "CodVivienda", "CodVivienda", visitum.CodVivienda);
            return View(visitum);
        }

        // GET: Visitums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitum = await _context.Visita
                .Include(v => v.CodBeneficiarioNavigation)
                .Include(v => v.CodViviendaNavigation)
                .FirstOrDefaultAsync(m => m.CodVisita == id);
            if (visitum == null)
            {
                return NotFound();
            }

            return View(visitum);
        }

        // POST: Visitums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var visitum = await _context.Visita.FindAsync(id);
            if (visitum != null)
            {
                _context.Visita.Remove(visitum);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VisitumExists(int id)
        {
            return _context.Visita.Any(e => e.CodVisita == id);
        }
    }
}
