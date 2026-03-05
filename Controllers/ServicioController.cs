using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Programacion_III.Data;
using Proyecto_Programacion_III.Models.Entidades;

public class ServicioController : Controller
{
    private readonly ApplicationDbContext _context;

    public ServicioController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var servicios = await _context.Servicios.ToListAsync();
        return View(servicios);
    }
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Servicio servicio)
    {
        if (ModelState.IsValid)
        {
            _context.Add(servicio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(servicio);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
            return NotFound();

        var servicio = await _context.Servicios.FindAsync(id);

        if (servicio == null)
            return NotFound();

        return View(servicio);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Servicio servicio)
    {
        if (id != servicio.ServicioId)
            return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(servicio);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Servicios.Any(e => e.ServicioId == servicio.ServicioId))
                    return NotFound();
                else
                    throw;
            }

            return RedirectToAction(nameof(Index));
        }

        return View(servicio);
    }
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
            return NotFound();

        var servicio = await _context.Servicios
            .FirstOrDefaultAsync(m => m.ServicioId == id);

        if (servicio == null)
            return NotFound();

        return View(servicio);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var servicio = await _context.Servicios.FindAsync(id);
        if (servicio != null)
        {
            _context.Servicios.Remove(servicio);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }
}
