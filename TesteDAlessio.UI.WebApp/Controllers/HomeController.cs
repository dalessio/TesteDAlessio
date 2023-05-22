using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TesteDAlessio.Domain.Entities;
using TesteDAlessio.Infrastructure.DBContext;
using TesteDAlessio.UI.WebApp.Models;

namespace TesteDAlessio.UI.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly TesteDAlessioDbContext _context;

        public HomeController(ILogger<HomeController> logger, TesteDAlessioDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            var model = new UsuarioModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(int id, [Bind("Login,Senha")] UsuarioModel usuario)
        {
            if (ModelState.IsValid)
            {
                if (_context.Usuarios.Any(u => u.Login == usuario.Login && u.Senha == usuario.Senha))
                {
                    return RedirectToAction(nameof(Index), "Contatos");
                }
                else
                {
                    usuario.Mensagem = "Login e/ou Senha inválido(s)!";
                    return View(usuario);
                }
            }

            usuario.Mensagem = "Problema ao Logar!";
            return View(usuario);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}