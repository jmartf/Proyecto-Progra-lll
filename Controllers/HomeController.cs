using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Programacion_III.Models;
using System.Diagnostics;
using Proyecto_Programacion_III.Data;

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
            ViewBag.TotalCitas = _context.Citas.Count();
            ViewBag.TotalClientes = _context.Clientes.Count();
            ViewBag.TotalServicios = _context.Servicios.Count();

            return View();
        }

        public IActionResult DashboardUsuario()
        {
            ViewBag.TotalCitas = _context.Citas.Count();

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