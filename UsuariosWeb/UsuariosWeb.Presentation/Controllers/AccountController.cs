using Microsoft.AspNetCore.Mvc;
using UsuariosWeb.Presentation.Models;

namespace UsuariosWeb.Presentation.Controllers
{
    public class AccountController : Controller
    {

        //abrir a página /Account/Login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(AccountLoginModel model)
        {
            if (ModelState.IsValid)
            {

            }

            return View();
        }

        //abrir a página /Account/Register
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(AccountRegisterModel model)
        {
            if (ModelState.IsValid)
            {

            }

            return View();
        }
    }
}
