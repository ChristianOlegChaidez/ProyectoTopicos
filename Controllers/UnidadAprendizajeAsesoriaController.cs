using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoTopicos.Models;

public class UnidadAprendizajeAsesoriaController : Controller
{
    private readonly ProyectoTopicosContext _context;

    public UnidadAprendizajeAsesoriaController(ProyectoTopicosContext context)
    {
        _context = context;
    }

    // GET: Index
    public async Task<IActionResult> Index()
    {
        return View(await _context.Unidad_aprendizaje_asesoria.ToListAsync());
    }

    // GET: Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("No,No_de_programa_Educativo,Programa_Educativo,Plan_de_estudios,Matricula_del_Alumno,Nombre_del_Alumno,Clave_de_la_materia,Nombre_de_la_Unidad_de_Aprendizaje_por_asesoria_Academica,Creditos_de_la_Unidad_de_Aprendizaje,No_de_empleado,Nombre_del_profesor,Grupo,CAPTURADO")] UnidadAprendizajeAsesoria item)
    {
        if (ModelState.IsValid)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(item);
    }

    // GET: Edit
    public async Task<IActionResult> Edit(double? id)
    {
        if (id == null) return NotFound();
        var item = await _context.Unidad_aprendizaje_asesoria.FindAsync(id);
        if (item == null) return NotFound();
        return View(item);
    }

    // POST: Edit
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(double id, [Bind("No,No_de_programa_Educativo,Programa_Educativo,Plan_de_estudios,Matricula_del_Alumno,Nombre_del_Alumno,Clave_de_la_materia,Nombre_de_la_Unidad_de_Aprendizaje_por_asesoria_Academica,Creditos_de_la_Unidad_de_Aprendizaje,No_de_empleado,Nombre_del_profesor,Grupo,CAPTURADO")] UnidadAprendizajeAsesoria item)
    {
        if (id != item.No) return NotFound();
        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(item);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Unidad_aprendizaje_asesoria.Any(e => e.No == item.No))
                    return NotFound();
                else
                    throw;
            }
            return RedirectToAction(nameof(Index));
        }
        return View(item);
    }

    // GET: Delete
    public async Task<IActionResult> Delete(double? id)
    {
        if (id == null) return NotFound();
        var item = await _context.Unidad_aprendizaje_asesoria.FirstOrDefaultAsync(m => m.No == id);
        if (item == null) return NotFound();
        return View(item);
    }

    // POST: Delete
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(double id)
    {
        var item = await _context.Unidad_aprendizaje_asesoria.FindAsync(id);
        if (item != null)
            _context.Unidad_aprendizaje_asesoria.Remove(item);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> BuscarAlumno(string nombre)
    {
        var alumnos = await _context.Alumno
            .Where(a => a.Nombre.ToUpper().Contains(nombre.ToUpper()))
            .Take(10)
            .Select(a => new { a.Matricula, a.Nombre })
            .ToListAsync();
        return Json(alumnos);
    }

    [HttpGet]
    public async Task<IActionResult> BuscarMaestro(string nombre)
    {
        var maestros = await _context.Maestros
            .Where(m => m.Nombre.ToUpper().Contains(nombre.ToUpper()))
            .Take(10)
            .Select(m => new { m.Numero_Empleado, m.Nombre })
            .ToListAsync();
        return Json(maestros);
    }

    [HttpGet]
    public async Task<IActionResult> BuscarMateria(string nombre)
    {
        var materias = await _context.Materias
            .Where(m => m.NombreUA.ToUpper().Contains(nombre.ToUpper()))
            .Take(10)
            .Select(m => new {
                m.ClaveUA,
                m.NombreUA,
                Creditos = (double?)m.Creditos,
                m.NoPE,
                m.NombrePE,
                m.PlanDeEstudios
            })
            .ToListAsync();
        return Json(materias);
    }

}