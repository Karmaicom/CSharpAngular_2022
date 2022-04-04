using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosWeb.Domain.Entities;
using UsuariosWeb.Domain.Interfaces.Repositories;

namespace UsuariosWeb.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private string _connectionString;

        public UsuarioRepository(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public void Inserir(Usuario entity)
        {
            var query = @"insert into usuario (idusuario, nome, email, senha, datacadastro, idperfil) values 
                          @IdUsuario, @Nome, @Email, @Senha, @DataCadastro, @IdPerfil";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(query, entity);
            }
        }

        public void Alterar(Usuario entity)
        {
            var query = @"update usuario set nome = @Nome, email = @Email,
                          senha = @Senha, idperfil = @IdPerfil";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(query, entity);
            }
        }
        public void Excluir(Usuario entity)
        {
            var query = @"delete from usuario where idusuario = @IdUsuario";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(query, entity);
            }
        }

        public Usuario? ObterPorId(Guid id)
        {
            var query = @"select * from usuario where idusuario = @id";

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Usuario>(query, new { id }).FirstOrDefault();
            }
        }

        public List<Usuario> Consultar()
        {
            var query = @"select * from usuario order by nome";

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Usuario>(query).ToList();
            }
        }

        public Usuario? Obter(string email)
        {
            var query = @"select * from usuario where email = @email";

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query(query, new { email }).FirstOrDefault();
            }
        }

        public Usuario? Obter(string email, string senha)
        {
            var query = @"select * from usuario where email = @email and senha = @senha";

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query(query, new { email, senha }).FirstOrDefault();
            }
        }
    }
}
