using Dapper;
using ProdutosApi.Infra.Data.Entities;
using ProdutosApi.Infra.Data.Interfaces;
using System.Data.SqlClient;

namespace ProdutosApi.Infra.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {

        private readonly string _connectionString;

        public ProdutoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Inserir(Produto entity)
        {
            var query = @"INSERT INTO PRODUTO(IDPRODUTO, NOME, PRECO, QUANTIDADE, DATACADASTRO)
                                VALUES (@IdProduto, @Nome, @Preco, @Quantidade, @DataCadastro)";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(query, entity);
            }
        }

        public void Alterar(Produto entity)
        {
            var query = @"UPDATE SET NOME = @Nome, PRECO = @Preco, QUANTIDADE = @Quantidade
                            WHERE IDPRODUTO = @IdProduto";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(query, entity);
            }
        }
        public void Excluir(Produto entity)
        {
            var query = @"DELETE FROM PRODUTO WHERE IDPRODUTO = @IdProduto";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(query, entity);
            }
        }

        public List<Produto> Consultar()
        {
            var query = @"SELECT * FROM PRODUTO ORDER BY NOME";

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Produto>(query).ToList();
            }
        }

        public Produto? ObterPorId(Guid id)
        {
            var query = @"SELECT * FROM PRODUTO WHERE IDPRODUTO = @IdProduto";

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Produto>(query, new { id }).FirstOrDefault();
            }
        }
    }
}
