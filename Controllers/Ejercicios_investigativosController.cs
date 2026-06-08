using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoTopicos.Models;

namespace ProyectoTopicos.Controllers
{
    public class Ejercicios_investigativosController : Controller
    {
        private readonly ProyectoTopicosContext _context;

    public Ejercicios_investigativosController(ProyectoTopicosContext context)
        {
            _context = context;
        }

        private void CargarCombos()
        {
            ViewBag.Alumnos = _context.Alumno
                .Where(a => a.Nombre != null)
                .ToList();

            ViewBag.Maestros = _context.Maestros
                .Where(m => m.Nombre != null)
                .ToList();

            ViewBag.Materias = _context.Materias
                .ToList();
        }

        // INDEX
        public async Task<IActionResult> Index()
        {
            var lista = await _context.Ejercicios_investigativos.ToListAsync();
            return View(lista);
        }

        // CREATE GET
        public IActionResult Create()
        {
            CargarCombos();
            return View();
        }

        // CREATE POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Ejercicios_investigativos ejercicio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ejercicio);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            CargarCombos();
            return View(ejercicio);
        }

        // EDIT GET
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var ejercicio = await _context.Ejercicios_investigativos
                .FirstOrDefaultAsync(e => e.No_de_programa_educativo == id);

            if (ejercicio == null)
                return NotFound();

            CargarCombos();

            return View(ejercicio);
        }

        // EDIT POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Ejercicios_investigativos ejercicio)
        {
            if (id != ejercicio.No_de_programa_educativo)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ejercicio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Ejercicios_investigativos
                        .Any(e => e.No_de_programa_educativo == id))
                    {
                        return NotFound();
                    }

                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            CargarCombos();
            return View(ejercicio);
        }

        // DELETE GET
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var ejercicio = await _context.Ejercicios_investigativos
                .FirstOrDefaultAsync(e => e.No_de_programa_educativo == id);

            if (ejercicio == null)
                return NotFound();

            return View(ejercicio);
        }

        // DELETE POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ejercicio = await _context.Ejercicios_investigativos
                .FirstOrDefaultAsync(e => e.No_de_programa_educativo == id);

            if (ejercicio != null)
            {
                _context.Ejercicios_investigativos.Remove(ejercicio);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }

}
