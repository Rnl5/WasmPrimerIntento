using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace WasmPrimerIntento.Server.Controllers
{
    public class AportesController : Controller
    {
        private readonly Context _context;

        public AportesController(Context context)
        {
            _context = context;
        }

        // GET: Aportes
        public async Task<IActionResult> Index()
        {
              return _context.Aportes != null ? 
                          View(await _context.Aportes.ToListAsync()) :
                          Problem("Entity set 'Context.Aportes'  is null.");
        }

        // GET: Aportes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Aportes == null)
            {
                return NotFound();
            }

            var aportes = await _context.Aportes
                .FirstOrDefaultAsync(m => m.AporteId == id);
            if (aportes == null)
            {
                return NotFound();
            }

            return View(aportes);
        }

        // GET: Aportes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Aportes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AporteId,Fecha,Persona,Observacion,Monto")] Aportes aportes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aportes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aportes);
        }

        // GET: Aportes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Aportes == null)
            {
                return NotFound();
            }

            var aportes = await _context.Aportes.FindAsync(id);
            if (aportes == null)
            {
                return NotFound();
            }
            return View(aportes);
        }

        // POST: Aportes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AporteId,Fecha,Persona,Observacion,Monto")] Aportes aportes)
        {
            if (id != aportes.AporteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aportes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AportesExists(aportes.AporteId))
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
            return View(aportes);
        }

        // GET: Aportes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Aportes == null)
            {
                return NotFound();
            }

            var aportes = await _context.Aportes
                .FirstOrDefaultAsync(m => m.AporteId == id);
            if (aportes == null)
            {
                return NotFound();
            }

            return View(aportes);
        }

        // POST: Aportes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Aportes == null)
            {
                return Problem("Entity set 'Context.Aportes'  is null.");
            }
            var aportes = await _context.Aportes.FindAsync(id);
            if (aportes != null)
            {
                _context.Aportes.Remove(aportes);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AportesExists(int id)
        {
          return (_context.Aportes?.Any(e => e.AporteId == id)).GetValueOrDefault();
        }
    }
}
