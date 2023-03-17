using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Money_Tracker.Models;

namespace Money_Tracker.Controllers
{
    public class TransaccionesController : Controller
    {
        private readonly AppDbContext _context;

        public TransaccionesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Transacciones
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Transacciones.Include(t => t.categoria);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Transacciones/Details/5
        /*
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Transacciones == null)
            {
                return NotFound();
            }

            var transaccion = await _context.Transacciones
                .Include(t => t.categoria)
                .FirstOrDefaultAsync(m => m.transaccionId == id);
            if (transaccion == null)
            {
                return NotFound();
            }

            return View(transaccion);
        }
        */

        // GET: Transacciones/Create
        public IActionResult Create()
        {
            llenarCategorias();
            return View();
        }

        // POST: Transacciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("transaccionId,categoriaID,transaccionMonto,transaccionDescripcion,transaccionFecha")] Transaccion transaccion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transaccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            llenarCategorias();
            return View(transaccion);
        }

        // GET: Transacciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Transacciones == null)
            {
                return NotFound();
            }

            var transaccion = await _context.Transacciones.FindAsync(id);
            if (transaccion == null)
            {
                return NotFound();
            }
            ViewData["categoriaID"] = new SelectList(_context.Categorias, "categoriaId", "categoriaId", transaccion.categoriaID);
            return View(transaccion);
        }

        // POST: Transacciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("transaccionId,categoriaID,transaccionMonto,transaccionDescripcion,transaccionFecha")] Transaccion transaccion)
        {
            if (id != transaccion.transaccionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaccion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransaccionExists(transaccion.transaccionId))
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
            ViewData["categoriaID"] = new SelectList(_context.Categorias, "categoriaId", "categoriaId", transaccion.categoriaID);
            return View(transaccion);
        }

        // GET: Transacciones/Delete/5
        /*
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Transacciones == null)
            {
                return NotFound();
            }

            var transaccion = await _context.Transacciones
                .Include(t => t.categoria)
                .FirstOrDefaultAsync(m => m.transaccionId == id);
            if (transaccion == null)
            {
                return NotFound();
            }

            return View(transaccion);
        }
        */

        // POST: Transacciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Transacciones == null)
            {
                return Problem("Entity set 'AppDbContext.Transacciones'  is null.");
            }
            var transaccion = await _context.Transacciones.FindAsync(id);
            if (transaccion != null)
            {
                _context.Transacciones.Remove(transaccion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransaccionExists(int id)
        {
          return _context.Transacciones.Any(e => e.transaccionId == id);
        }

        [NonAction]
        public void llenarCategorias()
        {
            var CategoriasColeccion = _context.Categorias.ToList();
            Categoria defaultCategoria = new Categoria() { categoriaId = 0, categoriaNombre = "Selecciona una categoría" };
            CategoriasColeccion.Insert(0, defaultCategoria);
            ViewBag.Categorias = CategoriasColeccion;

            foreach (var item in CategoriasColeccion)
            {
                System.Diagnostics.Debug.WriteLine(item.categoriaId);
            }
        }
    }
}