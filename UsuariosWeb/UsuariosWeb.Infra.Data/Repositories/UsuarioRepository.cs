using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosWeb.Domain.Entities;
using UsuariosWeb.Domain.Interfaces.Repositories;

namespace UsuariosWeb.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public void Inserir(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public void Alterar(Usuario entity)
        {
            throw new NotImplementedException();
        }
        public void Excluir(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public Usuario ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> Consultar()
        {
            throw new NotImplementedException();
        }

        public Usuario Obter(string email)
        {
            throw new NotImplementedException();
        }

        public Usuario Obter(string email, string senha)
        {
            throw new NotImplementedException();
        }
    }
}
