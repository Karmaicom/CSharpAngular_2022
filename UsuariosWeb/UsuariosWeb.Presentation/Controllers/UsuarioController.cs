using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UsuariosWeb.Presentation.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        public IActionResult Cadastro()
        {
            return View();
        }

        public IActionResult Consulta()
        {
            return View();
        }

        public IActionResult Relatorio()
        {
            return View();
        }

        public IActionResult MinhaConta()
        {
            return View();
        }
    }
}
