using Microsoft.AspNetCore.Mvc;
using UsuariosWeb.Domain.Entities;
using UsuariosWeb.Domain.Interfaces.Services;
using UsuariosWeb.Presentation.Models;

namespace UsuariosWeb.Presentation.Controllers
{
    public class AccountController : Controller
    {

        private readonly IUsuarioDomainService _usuarioDomainServive;

        public AccountController(IUsuarioDomainService usuarioDomainServive)
        {
            _usuarioDomainServive = usuarioDomainServive;
        }

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
                try
                {
                    var usuario = new Usuario
                    {
                        IdUsuario = Guid.NewGuid(),
                        Nome = model.Nome,
                        Email = model.Email,
                        Senha = model.Senha,
                        DataCadastro = DateTime.Now
                    };

                    _usuarioDomainServive.CadastrarUsuario(usuario);

                    TempData["MensagemSucesso"] = $"Parabéns {usuario.Nome}, sua conta foi cadastrada com sucesso.";
                }
                catch (Exception e)
                {
                    TempData["MensagemErro"] = e.Message;
                }
            }
            
            ModelState.Clear();

            return View();
        }
    }
}
