using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using notienendqver.Models;
using notienendqver.Models.ViewModels;

namespace notienendqver.Controllers
{
    public class ViviendumsController : Controller
    {
        private readonly AcroxOgContext _context;

        public ViviendumsController(AcroxOgContext context)
        {
            _context = context;
        }

        // GET: Viviendums
        public async Task<IActionResult> Index()
        {
            var acroxOgContext = _context.Vivienda.Include(v => v.CodBeneficiarioNavigation);
            var viviendas = _context.Vivienda
                            .Join(
                                _context.Beneficiarios,
                                vivienda => vivienda.CodBeneficiario,
                                beneficiario => beneficiario.CodBeneficiario,
                                (vivienda, beneficiario) => new ViviendaViewModel
                                {
                                    CodVivienda = vivienda.CodVivienda,
                                    DirVivienda = vivienda.DirVivienda,
                                    AreaVivienda = vivienda.AreaVivienda,
                                    FechaCreacion = vivienda.FechaCreacion,
                                    EstadoVivienda = vivienda.EstadoVivienda,
                                    TipoVivienda = vivienda.TipoVivienda,
                                    NombreCBeneficiario = beneficiario.NombreCBeneficiario,
                                    CodBeneficiarioNavigation = vivienda.CodBeneficiarioNavigation,
                                })
                            .ToList();

            return View(viviendas);
            //return View(await acroxOgContext.ToListAsync());
        }

        // GET: Viviendums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viviendum = await _context.Vivienda
                .Include(v => v.CodBeneficiarioNavigation)
                .FirstOrDefaultAsync(m => m.CodVivienda == id);
            if (viviendum == null)
            {
                return NotFound();
            }

            return View(viviendum);
        }

        // GET: Viviendums/Create
        public IActionResult Create()
        {
            ViewData["CodBeneficiario"] = new SelectList(_context.Beneficiarios, "CodBeneficiario", "NombreCBeneficiario");
            return View();
        }

        // POST: Viviendums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodVivienda,DirVivienda,AreaVivienda,EstadoVivienda,TipoVivienda,CodBeneficiario,FechaCreacion")] Viviendum viviendum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(viviendum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodBeneficiario"] = new SelectList(_context.Beneficiarios, "CodBeneficiario", "NombreCBeneficiario", viviendum.CodBeneficiario);
            return View(viviendum);
        }

        // GET: Viviendums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viviendum = await _context.Vivienda.FindAsync(id);
            if (viviendum == null)
            {
                return NotFound();
            }
            ViewData["CodBeneficiario"] = new SelectList(_context.Beneficiarios, "CodBeneficiario", "NombreCBeneficiario", viviendum.CodBeneficiario);
            return View(viviendum);
        }

        // POST: Viviendums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodVivienda,DirVivienda,AreaVivienda,EstadoVivienda,TipoVivienda,CodBeneficiario,FechaCreacion")] Viviendum viviendum)
        {
            if (id != viviendum.CodVivienda)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(viviendum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ViviendumExists(viviendum.CodVivienda))
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
            ViewData["CodBeneficiario"] = new SelectList(_context.Beneficiarios, "CodBeneficiario", "NombreCBeneficiario", viviendum.CodBeneficiario);
            return View(viviendum);
        }

        // GET: Viviendums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viviendum = await _context.Vivienda
                .Include(v => v.CodBeneficiarioNavigation)
                .FirstOrDefaultAsync(m => m.CodVivienda == id);
            if (viviendum == null)
            {
                return NotFound();
            }

            return View(viviendum);
        }

        // POST: Viviendums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var viviendum = await _context.Vivienda.FindAsync(id);
            if (viviendum != null)
            {
                _context.Vivienda.Remove(viviendum);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ViviendumExists(int id)
        {
            return _context.Vivienda.Any(e => e.CodVivienda == id);
        }
    }
}
