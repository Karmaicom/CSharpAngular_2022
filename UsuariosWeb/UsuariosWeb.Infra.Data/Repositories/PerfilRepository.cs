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
    public class PerfilRepository : IPerfilRepository
    {

        private string _connectionString;

        public PerfilRepository(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public void Inserir(Perfil entity)
        {
            var query = @"insert into perfil(idperfil, nome) values(@IdPerfil, @Nome)";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(query, entity);
            }
        }

        public void Alterar(Perfil entity)
        {
            var query = @"update perfil set nome = @Nome where idperfil = @IdPerfil";

            using (var connetion = new SqlConnection(_connectionString))
            {
                connetion.Execute(query, entity);
            }
        }

        public void Excluir(Perfil entity)
        {
            var query = @"delete from perfil where idperfil = @IdPerfil";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(query, entity);
            }
        }

        public List<Perfil> Consultar()
        {
            var query = @"select * from perfil order by nome";

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Perfil>(query).ToList();
            }
        }

        public Perfil? ObterPorId(Guid id)
        {
            var query = @"select * from perfil where idperfil = @id";

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Perfil>(query, new { id }).FirstOrDefault();
            }
        }

        public Perfil? Obter(string nome)
        {
            var query = @"select * from perfil where nome = @nome";

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Perfil>(query, new { nome }).FirstOrDefault();
            }
        }
    }
}
