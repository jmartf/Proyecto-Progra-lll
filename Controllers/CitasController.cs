using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Programacion_III.Data;
using Proyecto_Programacion_III.Models.Entidades;
using Proyecto_Programacion_III.Models.Entidades.Opciones;

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
            .Include(c => c.Servicio)
            .Include(c => c.Usuario); 

        return View(await citas.ToListAsync());
    }


    public IActionResult Create()
    {
        ViewBag.Clientes = _context.Clientes.ToList();
        ViewBag.Servicios = _context.Servicios.ToList();
        ViewBag.Usuarios = _context.Usuarios.ToList(); 
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Create(Cita cita)
    {
        cita.Estado = EstadoCita.Programada;
        if (cita.FechaHora < DateTime.Now)
        {
            ModelState.AddModelError("FechaHora", "No se pueden agendar citas en fechas pasadas");
        }
        var servicio = _context.Servicios
        .FirstOrDefault(s => s.ServicioId == cita.ServicioId);

        if (servicio != null && servicio.Estado == EstadoServicio.Inactivo)
        {
            ModelState.AddModelError("ServicioId", "El servicio se encuentra inactivo");
        }

        if (ModelState.IsValid)
        {
            _context.Citas.Add(cita);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        ViewBag.Clientes = _context.Clientes.ToList();
        ViewBag.Servicios = _context.Servicios.ToList();
        ViewBag.Usuarios = _context.Usuarios.ToList();

        return View(cita);
    }
    public async Task<IActionResult> Edit(int id)
    {
        var cita = await _context.Citas.FindAsync(id);

        if (cita == null)
            return NotFound();

        if (cita.Estado == EstadoCita.Cancelada)
            return RedirectToAction("Index");

        ViewBag.Clientes = _context.Clientes.ToList();
        ViewBag.Servicios = _context.Servicios.ToList();
        ViewBag.Usuarios = _context.Usuarios.ToList();

        return View(cita);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Cita cita)
    {
        var citaDb = await _context.Citas.FindAsync(cita.Id);

        if (citaDb == null)
            return NotFound();

        if (citaDb.Estado == EstadoCita.Cancelada)
        {
            ModelState.AddModelError("", "No se puede editar una cita cancelada");
        }

        if (cita.FechaHora < DateTime.Now)
        {
            ModelState.AddModelError("FechaHora", "No se pueden usar fechas pasadas");
        }

        var servicio = _context.Servicios
            .FirstOrDefault(s => s.ServicioId == cita.ServicioId);

        if (servicio != null && servicio.Estado == EstadoServicio.Inactivo)
        {
            ModelState.AddModelError("ServicioId", "Servicio inactivo");
        }

        if (ModelState.IsValid)
        {
            citaDb.ClienteId = cita.ClienteId;
            citaDb.ServicioId = cita.ServicioId;
            citaDb.UsuarioId = cita.UsuarioId;
            citaDb.FechaHora = cita.FechaHora;

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        ViewBag.Clientes = _context.Clientes.ToList();
        ViewBag.Servicios = _context.Servicios.ToList();
        ViewBag.Usuarios = _context.Usuarios.ToList();

        return View(cita);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var cita = await _context.Citas
            .Include(c => c.Cliente)
            .Include(c => c.Servicio)
            .Include(c => c.Usuario)
            .FirstOrDefaultAsync(c => c.Id == id); 

        return View(cita);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var cita = await _context.Citas.FindAsync(id);

        if (cita != null)
        {
            _context.Citas.Remove(cita);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction("Index");
    }
}