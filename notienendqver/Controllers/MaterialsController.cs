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
    public class MaterialsController : Controller
    {
        private readonly AcroxOgContext _context;

        public MaterialsController(AcroxOgContext context)
        {
            _context = context;
        }

        // GET: Materials
        public async Task<IActionResult> Index()
        {
            var acroxOgContext = _context.Materials.Include(m => m.CodAlmacenNavigation).Include(m => m.CodProveedorNavigation).Include(m => m.CodViviendaNavigation);
            /*var Materiales = _context.Materials.Join(
                                _context.Materials,
                                vivienda => vivienda.CodMaterial,
                                Material => Material.CodMaterial,
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
            */
            return View(await acroxOgContext.ToListAsync());
        }

        // GET: Materials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var material = await _context.Materials
                .Include(m => m.CodAlmacenNavigation)
                .Include(m => m.CodProveedorNavigation)
                .Include(m => m.CodViviendaNavigation)
                .FirstOrDefaultAsync(m => m.CodMaterial == id);
            if (material == null)
            {
                return NotFound();
            }

            return View(material);
        }

        // GET: Materials/Create
        public IActionResult Create()
        {
            ViewData["CodAlmacen"] = new SelectList(_context.Almacens, "CodAlmacen", "NombreAlmacen");
            ViewData["CodProveedor"] = new SelectList(_context.Proveedors, "CodProveedor", "NombProveedor");
            ViewData["CodVivienda"] = new SelectList(_context.Vivienda, "CodVivienda", "DirVivienda");
            return View();
        }

        // POST: Materials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodMaterial,NombMaterial,DescrpMaterial,PrecioMaterial,CodVivienda,CodProveedor,CodAlmacen,FechaCreacion")] Material material)
        {
            if (ModelState.IsValid)
            {
                _context.Add(material);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodAlmacen"] = new SelectList(_context.Almacens, "CodAlmacen", "CodAlmacen", material.CodAlmacen);
            ViewData["CodProveedor"] = new SelectList(_context.Proveedors, "CodProveedor", "CodProveedor", material.CodProveedor);
            ViewData["CodVivienda"] = new SelectList(_context.Vivienda, "CodVivienda", "CodVivienda", material.CodVivienda);
            return View(material);
        }

        // GET: Materials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var material = await _context.Materials.FindAsync(id);
            if (material == null)
            {
                return NotFound();
            }
            ViewData["CodAlmacen"] = new SelectList(_context.Almacens, "CodAlmacen", "NombreAlmacen", material.CodAlmacen);
            ViewData["CodProveedor"] = new SelectList(_context.Proveedors, "CodProveedor", "NombProveedor", material.CodProveedor);
            ViewData["CodVivienda"] = new SelectList(_context.Vivienda, "CodVivienda", "DirVivienda", material.CodVivienda);
            return View(material);
        }

        // POST: Materials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodMaterial,NombMaterial,DescrpMaterial,PrecioMaterial,CodVivienda,CodProveedor,CodAlmacen,FechaCreacion")] Material material)
        {
            if (id != material.CodMaterial)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(material);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaterialExists(material.CodMaterial))
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
            ViewData["CodAlmacen"] = new SelectList(_context.Almacens, "CodAlmacen", "CodAlmacen", material.CodAlmacen);
            ViewData["CodProveedor"] = new SelectList(_context.Proveedors, "CodProveedor", "CodProveedor", material.CodProveedor);
            ViewData["CodVivienda"] = new SelectList(_context.Vivienda, "CodVivienda", "CodVivienda", material.CodVivienda);
            return View(material);
        }

        // GET: Materials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var material = await _context.Materials
                .Include(m => m.CodAlmacenNavigation)
                .Include(m => m.CodProveedorNavigation)
                .Include(m => m.CodViviendaNavigation)
                .FirstOrDefaultAsync(m => m.CodMaterial == id);
            if (material == null)
            {
                return NotFound();
            }

            return View(material);
        }

        // POST: Materials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var material = await _context.Materials.FindAsync(id);
            if (material != null)
            {
                _context.Materials.Remove(material);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaterialExists(int id)
        {
            return _context.Materials.Any(e => e.CodMaterial == id);
        }
    }
}
