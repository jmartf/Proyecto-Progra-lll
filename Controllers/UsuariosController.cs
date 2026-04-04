using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Programacion_III.Models;
using Proyecto_Programacion_III.Models.Entidades;

namespace Proyecto_Programacion_III.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsuariosController(UserManager<Usuario> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            var usuarios = _userManager.Users.ToList();
            return View(usuarios);
        }
        public IActionResult Create()
        {
            ViewBag.Roles = _roleManager.Roles.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string email, string password, string role)
        {
            var usuario = new Usuario
            {
                UserName = email,
                Email = email
            };

            var resultado = await _userManager.CreateAsync(usuario, password);

            if (resultado.Succeeded)
            {
                await _userManager.AddToRoleAsync(usuario, role);
                return RedirectToAction("Index");
            }

            foreach (var error in resultado.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            
            ViewBag.Roles = _roleManager.Roles.ToList();
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var usuario = await _userManager.FindByIdAsync(id);

            if (usuario != null)
            {
                await _userManager.DeleteAsync(usuario);
            }

            return RedirectToAction("Index");
        }

    }
}
