
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoTopicos.Models;

public class Ayudantias_LaboratorioController : Controller
{
    private readonly ProyectoTopicosContext _context;

    public Ayudantias_LaboratorioController(ProyectoTopicosContext context)
    {
        _context = context;
    }

    // GET: AYUDANTIAS_LABORATORIOS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Ayudantias_Laboratorio.ToListAsync());
    }

    // GET: AYUDANTIAS_LABORATORIOS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var ayudantias_laboratorio = await _context.Ayudantias_Laboratorio
            .FirstOrDefaultAsync(m => m.id == id);
        if (ayudantias_laboratorio == null)
        {
            return NotFound();
        }

        return View(ayudantias_laboratorio);
    }

    // GET: AYUDANTIAS_LABORATORIOS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: AYUDANTIAS_LABORATORIOS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("id,no_programa,programa_educativo,plan_de_estudios,Matricula,Nombre_alumno,clave_ayudantia,nombre_ayudantia_lab,creditos_ayudantia,nombre_empleado,nombre_profesor")] Ayudantias_Laboratorio ayudantias_laboratorio)
    {
        if (ModelState.IsValid)
        {
            _context.Add(ayudantias_laboratorio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(ayudantias_laboratorio);
    }

    // GET: AYUDANTIAS_LABORATORIOS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var ayudantias_laboratorio = await _context.Ayudantias_Laboratorio.FindAsync(id);
        if (ayudantias_laboratorio == null)
        {
            return NotFound();
        }
        return View(ayudantias_laboratorio);
    }

    // POST: AYUDANTIAS_LABORATORIOS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("id,no_programa,programa_educativo,plan_de_estudios,Matricula,Nombre_alumno,clave_ayudantia,nombre_ayudantia_lab,creditos_ayudantia,nombre_empleado,nombre_profesor")] Ayudantias_Laboratorio ayudantias_laboratorio)
    {
        if (id != ayudantias_laboratorio.id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(ayudantias_laboratorio);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Ayudantias_LaboratorioExists(ayudantias_laboratorio.id))
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
        return View(ayudantias_laboratorio);
    }

    // GET: AYUDANTIAS_LABORATORIOS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var ayudantias_laboratorio = await _context.Ayudantias_Laboratorio
            .FirstOrDefaultAsync(m => m.id == id);
        if (ayudantias_laboratorio == null)
        {
            return NotFound();
        }

        return View(ayudantias_laboratorio);
    }

    // POST: AYUDANTIAS_LABORATORIOS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var ayudantias_laboratorio = await _context.Ayudantias_Laboratorio.FindAsync(id);
        if (ayudantias_laboratorio != null)
        {
            _context.Ayudantias_Laboratorio.Remove(ayudantias_laboratorio);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool Ayudantias_LaboratorioExists(int? id)
    {
        return _context.Ayudantias_Laboratorio.Any(e => e.id == id);
    }
}
