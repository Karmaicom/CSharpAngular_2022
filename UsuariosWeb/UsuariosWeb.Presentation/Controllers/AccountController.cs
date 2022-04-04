using Microsoft.AspNetCore.Mvc;

namespace UsuariosWeb.Presentation.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
