using Dapper;
using ProdutosApi.Infra.Data.Entities;
using ProdutosApi.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApi.Infra.Data.Repositories
{
    internal class ProdutoRepository : IProdutoRepository
    {

        private readonly string _connectionString;

        public ProdutoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Inserir(Produto entity)
        {
            var query = @"insert into produto(idproduto, nome, preco, quantidade, datacadastro)
                            values(@IdProduto, @Nome, @Preco, @Quantidade, @DataCadastro)";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(query, entity);
            }
        }

        public void Alterar(Produto entity)
        {
            var query = @"update produto nome = @Nome, preco = @Preco, quantidade = @Quantidade, datacadastro = @DataCadastro
                            where idproduto = @IdProduto";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(query, entity);
            }
        }

        public List<Produto> Consultar()
        {
            var query = @"select * from produto order by nome";

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Produto>(query).ToList();
            }
        }

        public void Delete(Produto entity)
        {
            var query = @"update from produto where idproduto = @IdProduto";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(query, entity);
            }
        }

        public Produto ObterPOrId(Guid id)
        {
            var query = @"select * from produto where idproduto = @IdProduto";

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Produto>(query, new { id }).FirstOrDefault();
            }
        }
    }
}
