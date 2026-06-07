using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoTopicos.Models;

namespace ProyectoTopicos.Controllers
{
    public class EstudiosIndependientesController : Controller
    {
        private readonly ProyectoTopicosContext _context;

        public EstudiosIndependientesController(ProyectoTopicosContext context)
        {
            _context = context;
        }

        // GET: EstudiosIndependientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.EstudiosIndependientes.ToListAsync());
        }

        // GET: EstudiosIndependientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var estudiosIndependientes = await _context.EstudiosIndependientes
                .FirstOrDefaultAsync(m => m.Clave_Estudio_Independiente == id);

            if (estudiosIndependientes == null) return NotFound();

            return View(estudiosIndependientes);
        }

        // GET: EstudiosIndependientes/Create
        public IActionResult Create()
        {
            ViewBag.Alumnos = _context.Alumno.Where(a => a.Nombre != null).ToList();
            ViewBag.Maestros = _context.Maestros.Where(m => m.Nombre != null).ToList();
            ViewBag.Materias = _context.Materias.ToList();
            return View();
        }

        // GET: EstudiosIndependientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var estudiosIndependientes = await _context.EstudiosIndependientes.FindAsync(id);
            if (estudiosIndependientes == null) return NotFound();

            return View(estudiosIndependientes);
        }

        // POST: EstudiosIndependientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("No,No_Programa_Educativo,Programa_Educativo,Plan_de_Estudios,Matricula,Nombre_Alumno,Clave_Estudio_Independiente,Nombre_Estudio_Independiente,Creditos_Estudio_Independiente,No_Empleado,Nombre_Profesor_Tutor_Investigar")] EstudiosIndependientes estudiosIndependientes)
        {
            if (id != estudiosIndependientes.Clave_Estudio_Independiente) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estudiosIndependientes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstudiosIndependientesExists(estudiosIndependientes.Clave_Estudio_Independiente))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(estudiosIndependientes);
        }

        // GET: EstudiosIndependientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var estudiosIndependientes = await _context.EstudiosIndependientes
                .FirstOrDefaultAsync(m => m.Clave_Estudio_Independiente == id);

            if (estudiosIndependientes == null) return NotFound();

            return View(estudiosIndependientes);
        }

        // POST: EstudiosIndependientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estudiosIndependientes = await _context.EstudiosIndependientes.FindAsync(id);
            if (estudiosIndependientes != null)
                _context.EstudiosIndependientes.Remove(estudiosIndependientes);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstudiosIndependientesExists(int id)
        {
            return _context.EstudiosIndependientes.Any(e => e.Clave_Estudio_Independiente == id);
        }

        // ── AUTOCOMPLETADO ────────────────────────────────────────────────────

        // Busca alumno por matrícula → regresa nombre
        [HttpGet]
        public IActionResult GetAlumno(int matricula)
        {
            var alumno = _context.Alumno
                .FirstOrDefault(a => a.Matricula == matricula);

            if (alumno == null)
                return Json(new { encontrado = false, nombre = "" });

            return Json(new { encontrado = true, nombre = alumno.Nombre });
        }

        // Busca maestro por número de empleado → regresa nombre
        [HttpGet]
        public IActionResult GetMaestro(string noEmpleado)
        {
            var maestro = _context.Maestros
                .FirstOrDefault(m => m.Numero_Empleado == noEmpleado);

            if (maestro == null)
                return Json(new { encontrado = false, nombre = "" });

            return Json(new { encontrado = true, nombre = maestro.Nombre });
        }

        // Busca materias por clave → regresa datos
        [HttpGet]
        public IActionResult GetMateria(int claveUA)
        {
            var materia = _context.Materias
                .FirstOrDefault(m => m.ClaveUA == claveUA);

            if (materia == null)
                return Json(new { encontrado = false });

            return Json(new
            {
                encontrado = true,
                nombre = materia.NombreUA,
                creditos = materia.Creditos,
                noPE = materia.NoPE,
                nombrePE = materia.NombrePE,
                plan = materia.PlanDeEstudios
            });
        }
    }
}