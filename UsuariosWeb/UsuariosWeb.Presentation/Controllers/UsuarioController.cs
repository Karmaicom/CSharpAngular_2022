using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UsuariosWeb.Domain.Entities;
using UsuariosWeb.Domain.Interfaces.Services;
using UsuariosWeb.Presentation.Models;

namespace UsuariosWeb.Presentation.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {

        private readonly IUsuarioDomainService _usuarioDomainService;

        public UsuarioController(IUsuarioDomainService usuarioDomainService)
        {
            _usuarioDomainService = usuarioDomainService;
        }

        public IActionResult Cadastro(UsuarioCadastroModel model)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var usuario = new Usuario{
                        IdUsuario = Guid.NewGuid(),
                        Nome = model.Nome,
                        Email = model.Email,
                        Senha = model.Senha,
                        DataCadastro = DateTime.Now
                    };

                    _usuarioDomainService.CadastrarUsuario(usuario);

                    ModelState.Clear();
                    TempData["MensagemSucesso"] = $"Usuário {usuario.Nome} cadastrado com sucesso!";

                }
                catch (Exception e)
                {
                    TempData["MensagemErro"] = e.Message;
                }
            }

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
            var model = new UsuarioMinhaContaModel();

            try
            {
                var usuario = _usuarioDomainService.ObterUsuario(User.Identity.Name);
            
                model.Nome = usuario.Nome;
                model.Email = usuario.Email;
                model.DataCadastro = usuario.DataCadastro;
                model.Perfil = usuario.Perfil.Nome.ToUpper();
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = e.Message;
            }

            return View(model);
        }
    }
}
