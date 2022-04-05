using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosWeb.Domain.Entities;

namespace UsuariosWeb.Domain.Interfaces.Services
{
    public interface IUsuarioDomainService
    {

        void CadastrarUsuario(Usuario usuario);

        Usuario AutenticarUsuario(string email, string senha);

    }
}
