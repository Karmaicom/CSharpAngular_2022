using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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
                try
                {
                    var usuario = _usuarioDomainServive.AutenticarUsuario(model.Email, model.Senha);

                    #region Criar a permissão de acesso do usuário

                    var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, usuario.Email) },
                        CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    #endregion

                    return RedirectToAction("Index", "Home");
                }
                catch (Exception e)
                {

                    TempData["MensagemErro"] = e.Message;
                }

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

        public IActionResult Logout()
        {

            #region Remover a permissão de acesso ao usuário

            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            #endregion

            return RedirectToAction("Login", "Account");

        }
    }
}
