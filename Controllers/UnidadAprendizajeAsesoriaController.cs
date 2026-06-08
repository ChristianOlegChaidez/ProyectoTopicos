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
    public async Task<IActionResult> BuscarMateria(string nombre)
    {
        var todasMaterias = await _context.Materias.ToListAsync();

        var materias = todasMaterias
            .Where(m => NormalizarTexto(m.NombreUA).Contains(NormalizarTexto(nombre)))
            .Take(10)
            .Select(m => new { m.ClaveUA, m.NombreUA, m.Creditos, m.NoPE, m.NombrePE, m.PlanDeEstudios })
            .ToList();

        return Json(materias);
    }

    [HttpGet]
    public async Task<IActionResult> BuscarAlumno(string nombre)
    {
        var todos = await _context.Alumno.ToListAsync();

        var alumnos = todos
            .Where(a => NormalizarTexto(a.Nombre).Contains(NormalizarTexto(nombre))
                     || a.Matricula.ToString().Contains(nombre))
            .Take(10)
            .Select(a => new { a.Matricula, a.Nombre })
            .ToList();

        return Json(alumnos);
    }

    [HttpGet]
    public async Task<IActionResult> BuscarMaestro(string nombre)
    {
        var todos = await _context.Maestros.ToListAsync();

        var maestros = todos
            .Where(m => NormalizarTexto(m.Nombre).Contains(NormalizarTexto(nombre)))
            .Take(10)
            .Select(m => new { m.Numero_Empleado, m.Nombre })
            .ToList();

        return Json(maestros);
    }

    private string NormalizarTexto(string texto)
    {
        if (string.IsNullOrEmpty(texto)) return "";
        var normalized = texto.Normalize(System.Text.NormalizationForm.FormD);
        var sb = new System.Text.StringBuilder();
        foreach (var c in normalized)
        {
            if (System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c)
                != System.Globalization.UnicodeCategory.NonSpacingMark)
                sb.Append(c);
        }
        return sb.ToString().ToUpper();
    }

}