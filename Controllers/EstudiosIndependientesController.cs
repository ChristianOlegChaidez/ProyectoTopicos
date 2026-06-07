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

        // Helper para cargar ViewBag
        private void CargarViewBag()
        {
            ViewBag.Alumnos = _context.Alumno.Where(a => a.Nombre != null).ToList();
            ViewBag.Maestros = _context.Maestros.Where(m => m.Nombre != null).ToList();
            ViewBag.Materias = _context.Materias.ToList();
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

            var estudio = await _context.EstudiosIndependientes
                .FirstOrDefaultAsync(m => m.Clave_Estudio_Independiente == id);

            if (estudio == null) return NotFound();

            return View(estudio);
        }

        // GET: EstudiosIndependientes/Create
        public IActionResult Create()
        {
            CargarViewBag();
            return View();
        }

        // POST: EstudiosIndependientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("No_Programa_Educativo,Programa_Educativo,Plan_de_Estudios,Matricula,Nombre_Alumno,Clave_Estudio_Independiente,Nombre_Estudio_Independiente,Creditos_Estudio_Independiente,No_Empleado,Nombre_Profesor_Tutor_Investigar")] EstudiosIndependientes estudio)
        {
            if (ModelState.IsValid)
            {
                // No = siguiente número consecutivo automático
                estudio.No = _context.EstudiosIndependientes.Count() + 1;
                _context.Add(estudio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            CargarViewBag();
            return View(estudio);
        }

        // GET: EstudiosIndependientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var estudio = await _context.EstudiosIndependientes.FindAsync(id);
            if (estudio == null) return NotFound();

            CargarViewBag();
            return View(estudio);
        }

        // POST: EstudiosIndependientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("No,No_Programa_Educativo,Programa_Educativo,Plan_de_Estudios,Matricula,Nombre_Alumno,Clave_Estudio_Independiente,Nombre_Estudio_Independiente,Creditos_Estudio_Independiente,No_Empleado,Nombre_Profesor_Tutor_Investigar")] EstudiosIndependientes estudio)
        {
            if (id != estudio.Clave_Estudio_Independiente) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estudio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstudiosIndependientesExists(estudio.Clave_Estudio_Independiente))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            CargarViewBag();
            return View(estudio);
        }

        // GET: EstudiosIndependientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var estudio = await _context.EstudiosIndependientes
                .FirstOrDefaultAsync(m => m.Clave_Estudio_Independiente == id);

            if (estudio == null) return NotFound();

            return View(estudio);
        }

        // POST: EstudiosIndependientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estudio = await _context.EstudiosIndependientes.FindAsync(id);
            if (estudio != null)
                _context.EstudiosIndependientes.Remove(estudio);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstudiosIndependientesExists(int id)
        {
            return _context.EstudiosIndependientes.Any(e => e.Clave_Estudio_Independiente == id);
        }

        // ── AUTOCOMPLETADO ────────────────────────────────────────────────────

        [HttpGet]
        public IActionResult GetAlumno(int matricula)
        {
            var alumno = _context.Alumno
                .FirstOrDefault(a => a.Matricula == matricula);

            if (alumno == null)
                return Json(new { encontrado = false, nombre = "" });

            return Json(new { encontrado = true, nombre = alumno.Nombre });
        }

        [HttpGet]
        public IActionResult GetMaestro(string noEmpleado)
        {
            var maestro = _context.Maestros
                .FirstOrDefault(m => m.Numero_Empleado == noEmpleado);

            if (maestro == null)
                return Json(new { encontrado = false, nombre = "" });

            return Json(new { encontrado = true, nombre = maestro.Nombre });
        }

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
