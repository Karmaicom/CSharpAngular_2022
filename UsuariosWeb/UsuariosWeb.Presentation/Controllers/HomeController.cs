using Microsoft.AspNetCore.Mvc;

namespace UsuariosWeb.Presentation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
