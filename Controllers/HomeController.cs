using Microsoft.AspNetCore.Mvc;
using Proyecto_Programacion_III.Data;
using Proyecto_Programacion_III.Models;
using Proyecto_Programacion_III.Models.Entidades.Opciones;
using System.Diagnostics;

namespace Proyecto_Programacion_III.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult LoginAdmin()
        {
            HttpContext.Session.SetString("Rol", "Administrador");
            return RedirectToAction("Index");
        }


        public IActionResult LoginUsuario()
        {
            HttpContext.Session.SetString("Rol", "Usuario");
            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult DashboardAdmin()
        {

            ViewBag.TotalUsuarios = _context.Usuarios.Count();
            ViewBag.TotalClientes = _context.Clientes.Count();
            ViewBag.TotalCitas = _context.Citas.Count();


            ViewBag.ServiciosActivos = _context.Servicios
                .Count(s => s.Estado == EstadoServicio.Activo);

            ViewBag.ServiciosInactivos = _context.Servicios
                .Count(s => s.Estado == EstadoServicio.Inactivo);

            ViewBag.CitasProgramadas = _context.Citas
                .Count(c => c.Estado == EstadoCita.Programada);

            ViewBag.CitasCanceladas = _context.Citas
                .Count(c => c.Estado == EstadoCita.Cancelada);


            var topServicios = _context.Citas
                .GroupBy(c => c.Servicio.Nombre)
                .Select(g => new
                {
                    Servicio = g.Key,
                    Total = g.Count()
                })
                .OrderByDescending(x => x.Total)
                .Take(3)
                .ToList();

            ViewBag.TopServicios = topServicios;

            return View();
        }

        public IActionResult DashboardUsuario()
        {

            ViewBag.TotalCitas = _context.Citas.Count();

            ViewBag.ServiciosActivos = _context.Servicios
               .Count(s => s.Estado == EstadoServicio.Activo);

            ViewBag.ServiciosInactivos = _context.Servicios
                .Count(s => s.Estado == EstadoServicio.Inactivo);

            ViewBag.CitasProgramadas = _context.Citas
                .Count(c => c.Estado == EstadoCita.Programada);

            ViewBag.CitasCanceladas = _context.Citas
                .Count(c => c.Estado == EstadoCita.Cancelada);

            ViewBag.Citas = _context.Citas.ToList();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}