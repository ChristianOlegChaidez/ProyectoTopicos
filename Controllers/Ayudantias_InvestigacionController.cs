
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoTopicos.Models;

public class Ayudantias_InvestigacionController : Controller
{
    private readonly ProyectoTopicosContext _context;

    public Ayudantias_InvestigacionController(ProyectoTopicosContext context)
    {
        _context = context;
    }

    // GET: AYUDANTIAS_INVESTIGACIONS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Ayudantias.ToListAsync());
    }

    // GET: AYUDANTIAS_INVESTIGACIONS/Details/5
    public async Task<IActionResult> Details(int? clave_ayudantias)
    {
        if (clave_ayudantias == null)
        {
            return NotFound();
        }

        var ayudantias_investigacion = await _context.Ayudantias
            .FirstOrDefaultAsync(m => m.Clave_Ayudantias == clave_ayudantias);
        if (ayudantias_investigacion == null)
        {
            return NotFound();
        }

        return View(ayudantias_investigacion);
    }

    public async Task<IActionResult> DeleteSearch()
    {
        return View(await _context.Ayudantias.ToListAsync());
    }

    public async Task<IActionResult> EditSearch()
    {
        return View(await _context.Ayudantias.ToListAsync());
    }

    // GET: AYUDANTIAS_INVESTIGACIONS/Create
    public IActionResult Create()
    {
        ViewBag.Alumnos = _context.Alumno.Where(a => a.Nombre != null).ToList();
        ViewBag.Maestros = _context.Maestros.Where(m => m.Nombre != null).ToList();
        ViewBag.Materias = _context.Materias.ToList();
        return View();
    }

    // POST: AYUDANTIAS_INVESTIGACIONS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Clave_Ayudantias,Programa_Educativo,No_Programa_Educativo,Plan_Estudios,Matricula,Nombre_Alumno,Nombre_de_Ayudantia,Creditos_de_Ayudantia,No_de_Empleado,Nombre_Empleado")] Ayudantias_Investigacion ayudantias_investigacion)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _context.Add(ayudantias_investigacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }
        ViewBag.Alumnos = _context.Alumno.Where(a => a.Nombre != null).ToList();
        ViewBag.Maestros = _context.Maestros.Where(m => m.Nombre != null).ToList();
        ViewBag.Materias = _context.Materias.ToList();
        return View(ayudantias_investigacion);
    }

    // GET: AYUDANTIAS_INVESTIGACIONS/Edit/5
    public async Task<IActionResult> Edit(int? clave_ayudantias)
    {
        if (clave_ayudantias == null)
        {
            return NotFound();
        }

        var ayudantias_investigacion = await _context.Ayudantias.FindAsync(clave_ayudantias);
        if (ayudantias_investigacion == null)
        {
            return NotFound();
        }
        return View(ayudantias_investigacion);
    }

    // POST: AYUDANTIAS_INVESTIGACIONS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? clave_ayudantias, [Bind("Clave_Ayudantias,Programa_Educativo,No_Programa_Educativo,Plan_Estudios,Matricula,Nombre_Alumno,Nombre_de_Ayudantia,Creditos_de_Ayudantia,No_de_Empleado,Nombre_Empleado")] Ayudantias_Investigacion ayudantias_investigacion)
    {
        if (clave_ayudantias != ayudantias_investigacion.Clave_Ayudantias)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(ayudantias_investigacion);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Ayudantias_InvestigacionExists(ayudantias_investigacion.Clave_Ayudantias))
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
        return View(ayudantias_investigacion);
    }

    // GET: AYUDANTIAS_INVESTIGACIONS/Delete/5
    public async Task<IActionResult> Delete(int? clave_ayudantias)
    {
        if (clave_ayudantias == null)
        {
            return NotFound();
        }

        var ayudantias_investigacion = await _context.Ayudantias
            .FirstOrDefaultAsync(m => m.Clave_Ayudantias == clave_ayudantias);
        if (ayudantias_investigacion == null)
        {
            return NotFound();
        }

        return View(ayudantias_investigacion);
    }

    // POST: AYUDANTIAS_INVESTIGACIONS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? clave_ayudantias)
    {
        var ayudantias_investigacion = await _context.Ayudantias.FindAsync(clave_ayudantias);
        if (ayudantias_investigacion != null)
        {
            _context.Ayudantias.Remove(ayudantias_investigacion);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool Ayudantias_InvestigacionExists(int? clave_ayudantias)
    {
        return _context.Ayudantias.Any(e => e.Clave_Ayudantias == clave_ayudantias);
    }
}
