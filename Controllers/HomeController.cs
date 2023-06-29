using UsandoViews.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace UsandoViews.Controllers
{
    public class HomeController : Controller
    {
/*        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
*/
        public IActionResult Index()
        {
            ViewData["NReg"] = Usuario.Listagem.Count();
            return View();
        }
        public IActionResult Usuarios()
        {
            return View(Usuario.Listagem);
        }
        
        [HttpGet]   
        public IActionResult Cadastrar(int? id)
        {
            if (id.HasValue && Usuario.Listagem.Any(u => u.IdUsuario == id))
            {
                var usuario = Usuario.Listagem.Single(u => u.IdUsuario == id);
                return View(usuario);
            }
            return View();
        }
        [HttpPost]   
        public IActionResult Cadastrar(Usuario usuario)
        {
            Usuario.Salvar(usuario);
            return RedirectToAction("Usuarios");
        }

        [HttpGet]   
        public IActionResult Excluir(int? id)
        {
            if (id.HasValue && Usuario.Listagem.Any(u => u.IdUsuario == id))
            {
                var usuario = Usuario.Listagem.Single(u => u.IdUsuario == id);
                return View(usuario);
            }
            return View("Usuarios");
        }
        [HttpPost]   
        public IActionResult Excluir(Usuario usuario)
        {

            
            TempData["Excluiu"] =  Usuario.Excluir(usuario.IdUsuario);
            //return View("Usuarios");
            return RedirectToAction("Usuarios");


            
        }        

        /*[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }*/
    }
}