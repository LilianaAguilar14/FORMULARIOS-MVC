using FORMULARIOS_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FORMULARIOS_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MvcContext _context;

        public HomeController(ILogger<HomeController> logger, MvcContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Usuario usuario)
        {

            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(usuario);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
