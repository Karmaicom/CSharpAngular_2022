using AgendaWeb.Presentation.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgendaWeb.Presentation.Controllers
{
    public class TarefaController : Controller
    {
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(TarefaCadastroModel model)
        {
            return View();
        }

        public IActionResult Consulta()
        {
            return View();
        }
    }
}
