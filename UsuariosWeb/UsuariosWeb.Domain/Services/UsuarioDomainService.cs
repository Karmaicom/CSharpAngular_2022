using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosWeb.Domain.Entities;
using UsuariosWeb.Domain.Interfaces.Services;

namespace UsuariosWeb.Domain.Services
{
    public class UsuarioDomainService : IUsuarioDomainService
    {
        public Usuario AutenticarUsuario(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public void CadastrarUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
