using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosWeb.Domain.Entities;
using UsuariosWeb.Domain.Interfaces.Repositories;
using UsuariosWeb.Domain.Interfaces.Services;

namespace UsuariosWeb.Domain.Services
{
    public class UsuarioDomainService : IUsuarioDomainService
    {

        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IPerfilRepository _perfilRepository;

        public UsuarioDomainService(IUsuarioRepository usuarioRepository, IPerfilRepository perfilRepository)
        {
            _usuarioRepository = usuarioRepository;
            _perfilRepository = perfilRepository;
        }

        public void CadastrarUsuario(Usuario usuario)
        {
            if (_usuarioRepository.Obter(usuario.Email) != null)
            {
                throw new Exception($"O email '{usuario.Email}' já está cadastrado no sistema.");
            }

            var perfil = _perfilRepository.Obter("default");
            usuario.IdPerfil = perfil.IdPerfil;

            _usuarioRepository.Inserir(usuario);            
        }

        public Usuario AutenticarUsuario(string email, string senha)
        {
            throw new NotImplementedException();
        }
    }
}
