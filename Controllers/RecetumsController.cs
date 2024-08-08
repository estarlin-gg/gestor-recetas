using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using proyectoFinal.Models;
using Rotativa;
using Rotativa.AspNetCore;

namespace proyectoFinal.Controllers
{
    public class RecetumsController(GestorRecetaContext context) : Controller
    {
        private readonly GestorRecetaContext _context = context;

        // GET: Recetums
        public async Task<IActionResult> Index(string search)
        {
            var recetas = from r in _context.Receta select r;

            if (!string.IsNullOrEmpty(search))
            {
                recetas = recetas.Where(rec => rec.NombrePaciente.Contains(search));

            }
            return View(await recetas.ToListAsync());
        }

       public ActionResult Print(int id)
{
    var recetum = _context.Receta.FirstOrDefault(r => r.Id == id);
    if (recetum == null)
    {
        return NotFound();
    }

    return new ViewAsPdf("PrintDetails", recetum);
}

        // GET: Recetums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recetum = await _context.Receta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recetum == null)
            {
                return NotFound();
            }

            return View(recetum);
        }

        // GET: Recetums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recetums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombrePaciente,ApellidoPaciente,TelefonoPaciente,DireccionPaciente,Fecha,NombreDoctor,Medicamentos")] Recetum recetum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recetum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recetum);
        }

        // GET: Recetums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recetum = await _context.Receta.FindAsync(id);
            if (recetum == null)
            {
                return NotFound();
            }
            return View(recetum);
        }

        // POST: Recetums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombrePaciente,ApellidoPaciente,TelefonoPaciente,DireccionPaciente,Fecha,NombreDoctor,Medicamentos")] Recetum recetum)
        {
            if (id != recetum.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recetum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecetumExists(recetum.Id))
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
            return View(recetum);
        }

        // GET: Recetums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recetum = await _context.Receta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recetum == null)
            {
                return NotFound();
            }

            return View(recetum);
        }

        // POST: Recetums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recetum = await _context.Receta.FindAsync(id);
            if (recetum != null)
            {
                _context.Receta.Remove(recetum);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecetumExists(int id)
        {
            return _context.Receta.Any(e => e.Id == id);
        }



    }
}
