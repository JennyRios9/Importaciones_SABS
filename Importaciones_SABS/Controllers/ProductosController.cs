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
    public class ProductosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Productos
        public async Task<IActionResult> Listar()
        {
            await using (_context)
            {
                IEnumerable<ProductosDto> ListaProductos =
                    (from productos  in _context.Productos
                     join categoria in _context.Categoria
                     on productos.Id_categoria equals 
                     categoria.IdCategoria
                     select new ProductosDto
                     {
                         Id = productos.Id, 
                         Codigo = productos.Codigo, 
                         NombreProducto = productos.NombreProducto, 
                         ValorUnitario = productos.ValorUnitario,   
                         Iva = productos.Iva,
                         Cantidad = productos.Cantidad,
                         FechaRegistro = productos.FechaRegistro,
                         Estado = productos.Estado,
                         NombreCategoria = categoria.NombreCategoria,

                     }
                     ).ToList();    
                return View(ListaProductos);
            }

               
        }

        // GET: Productos/Detalle/5
        public async Task<IActionResult> Detalle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productos = await _context.Productos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productos == null)
            {
                return NotFound();
            }

            return View(productos);
        }

        // GET: Productos/Registrar
        public IActionResult Registrar()
        {
            return View();
        }

        // POST: Productos/Registrar
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registrar([Bind("Id,Codigo,NombreProducto,ValorUnitario,Iva,Cantidad,FechaRegistro,Estado,Id_categoria")] Productos productos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Listar));
            }
            return View(productos);
        }

        // GET: Productos/Editar/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productos = await _context.Productos.FindAsync(id);
            if (productos == null)
            {
                return NotFound();
            }
            return View(productos);
        }

        // POST: Productos/Editar/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("Id,Codigo,NombreProducto,ValorUnitario,Iva,Cantidad,FechaRegistro,Estado,Id_categoria")] Productos productos)
        {
            if (id != productos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductosExists(productos.Id))
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
            return View(productos);
        }

        // GET: Productos/Eliminar/5
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productos = await _context.Productos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productos == null)
            {
                return NotFound();
            }

            return View(productos);
        }

        // POST: Productos/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productos = await _context.Productos.FindAsync(id);
            _context.Productos.Remove(productos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Listar));
        }

        private bool ProductosExists(int id)
        {
            return _context.Productos.Any(e => e.Id == id);
        }
    }
}
