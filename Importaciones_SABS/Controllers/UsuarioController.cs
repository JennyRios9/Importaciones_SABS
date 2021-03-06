using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Importaciones_SABS.Datos;
using Importaciones_SABS.Models;
using Importaciones_SABS.ClaseDto;

namespace Importaciones_SABS.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsuarioController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Usuario
        public async Task<IActionResult> Listar()
        {
            await using (_context)
            {
                IEnumerable<UsuariosDto> ListaUsuarios =
                    (from usuarios in _context.Usuarios
                     join rol in _context.Roles
                     on usuarios.rol_id equals
                     rol.Id
                     select new UsuariosDto
                     {
                         Id = usuarios.Id,
                         Nombre = usuarios.Nombre,
                         Apellido = usuarios.Apellido,
                         Cedula = usuarios.Cedula,
                         Telefono = usuarios.Telefono,
                         Correo = usuarios.Correo,
                         Estado = usuarios.Estado,
                         rol_id = rol.Id,
                         Rol = rol.Nombre

                     }
                    ).ToList();
                return View(ListaUsuarios);
            }

        }

        // GET: Usuario/Detalle/5
        public async Task<IActionResult> Detalle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarios = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarios == null)
            {
                return NotFound();
            }

            return View(usuarios);
        }

        // GET: Usuario/Registrar
        public IActionResult Registrar()
        {
            return View();
        }

        // POST: Usuario/Registrar
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registrar([Bind("Id,Nombre,Apellido,Cedula,Telefono,Correo,Estado,rol_id")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuarios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Listar));
            }
            return View(usuarios);
        }

        // GET: Usuario/Editar/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarios = await _context.Usuarios.FindAsync(id);
            if (usuarios == null)
            {
                return NotFound();
            }
            return View(usuarios);
        }

        // POST: Usuario/Editar/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("Id,Nombre,Apellido,Cedula,Telefono,Correo,Estado,rol_id")] Usuarios usuarios)
        {
            if (id != usuarios.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuarios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuariosExists(usuarios.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Listar));
            }
            return View(usuarios);
        }

        // GET: Usuario/Eliminar/5
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarios = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarios == null)
            {
                return NotFound();
            }

            return View(usuarios);
        }

        // POST: Usuario/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuarios = await _context.Usuarios.FindAsync(id);
            _context.Usuarios.Remove(usuarios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Listar));
        }

        private bool UsuariosExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}
