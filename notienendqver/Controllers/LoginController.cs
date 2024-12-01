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
    public class LoginController : Controller
    {
        private readonly AcroxOgContext _context;

        public LoginController(AcroxOgContext context)
        {
            _context = context;
        }

        // GET: Login
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuarios.ToListAsync());
        }

        // GET: Login/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.CodUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Login/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodUsuario,NombreUsuario,ClaveUsuario,FechaCreacion")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }
        public async Task<IActionResult> Verificar(string user,string contra)
        {
            if (user == null||contra ==null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.NombreUsuario == user);
            if (usuario == null)
            {
                return NotFound();
            }
            bool esValido = VerificarContraseña(usuario, contra);
            if (!esValido)
            {
                // Opcional: Puedes devolver un mensaje de error o simplemente NotFound() si no quieres dar detalles específicos.
                return NotFound();
            }
            return Ok(new { success = true, usuarioId = usuario.CodUsuario });

        }
        // GET: Login/Edit/5
        private bool VerificarContraseña(Usuario usuario, string contraseña)
        {
            // Implementa tu lógica para verificar la contraseña aquí.
            // Por ejemplo, podrías comparar la contraseña proporcionada con la contraseña hash almacenada en la base de datos.
            // Este es solo un ejemplo básico, asegúrate de implementar un método seguro para verificar contraseñas en tu aplicación.
            return usuario.ClaveUsuario == contraseña;
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Login/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodUsuario,NombreUsuario,ClaveUsuario,FechaCreacion")] Usuario usuario)
        {
            if (id != usuario.CodUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.CodUsuario))
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
            return View(usuario);
        }

        // GET: Login/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.CodUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Login/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.CodUsuario == id);
        }
    }
}
