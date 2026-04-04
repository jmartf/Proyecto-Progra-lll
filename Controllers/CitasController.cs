using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Programacion_III.Data;
using Proyecto_Programacion_III.Models.Entidades;

public class CitasController : Controller
{
    private readonly ApplicationDbContext _context;

    public CitasController(ApplicationDbContext context)
    {
        _context = context;
    }


    public async Task<IActionResult> Index()
    {
        var citas = _context.Citas
            .Include(c => c.Cliente)
            .Include(c => c.Servicio);

        return View(await citas.ToListAsync());
    }


    public IActionResult Create()
    {
        ViewBag.Clientes = _context.Clientes.ToList();
        ViewBag.Servicios = _context.Servicios.ToList();
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Create(Cita cita)
    {
        if (ModelState.IsValid)
        {
            _context.Add(cita);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        ViewBag.Clientes = _context.Clientes.ToList();
        ViewBag.Servicios = _context.Servicios.ToList();
        return View(cita);
    }


    public async Task<IActionResult> Delete(int id)
    {
        var cita = await _context.Citas
            .Include(c => c.Cliente)
            .Include(c => c.Servicio)
            .FirstOrDefaultAsync(c => c.CitaId == id);

        return View(cita);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var cita = await _context.Citas.FindAsync(id);
        _context.Citas.Remove(cita);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
}
