
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoTopicos.Models;

public class AlumnoesController : Controller
{
    private readonly ProyectoTopicosContext _context;

    public AlumnoesController(ProyectoTopicosContext context)
    {
        _context = context;
    }

    // GET: ALUMNOS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Alumno.ToListAsync());
    }

    // GET: ALUMNOS/Details/5
    public async Task<IActionResult> Details(int? matricula)
    {
        if (matricula == null)
        {
            return NotFound();
        }

        var alumno = await _context.Alumno
            .FirstOrDefaultAsync(m => m.Matricula == matricula);
        if (alumno == null)
        {
            return NotFound();
        }

        return View(alumno);
    }

    // GET: ALUMNOS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: ALUMNOS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Matricula,Nombre,Puntos,Promedio,Creditos")] Alumno alumno)
    {
        if (ModelState.IsValid)
        {
            _context.Add(alumno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(alumno);
    }

    // GET: ALUMNOS/Edit/5
    public async Task<IActionResult> Edit(int? matricula)
    {
        if (matricula == null)
        {
            return NotFound();
        }

        var alumno = await _context.Alumno.FindAsync(matricula);
        if (alumno == null)
        {
            return NotFound();
        }
        return View(alumno);
    }

    // POST: ALUMNOS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? matricula, [Bind("Matricula,Nombre,Puntos,Promedio,Creditos")] Alumno alumno)
    {
        if (matricula != alumno.Matricula)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(alumno);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlumnoExists(alumno.Matricula))
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
        return View(alumno);
    }

    // GET: ALUMNOS/Delete/5
    public async Task<IActionResult> Delete(int? matricula)
    {
        if (matricula == null)
        {
            return NotFound();
        }

        var alumno = await _context.Alumno
            .FirstOrDefaultAsync(m => m.Matricula == matricula);
        if (alumno == null)
        {
            return NotFound();
        }

        return View(alumno);
    }

    // POST: ALUMNOS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? matricula)
    {
        var alumno = await _context.Alumno.FindAsync(matricula);
        if (alumno != null)
        {
            _context.Alumno.Remove(alumno);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool AlumnoExists(int? matricula)
    {
        return _context.Alumno.Any(e => e.Matricula == matricula);
    }
}
