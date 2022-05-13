using ProdutosApi.Infra.Data.Entities;
using ProdutosApi.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
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

        public void Alterar(Produto entity)
        {
            throw new NotImplementedException();
        }

        public List<Produto> Consultar()
        {
            throw new NotImplementedException();
        }

        public void Excluir(Produto entity)
        {
            throw new NotImplementedException();
        }

        public void Inerir(Produto entity)
        {
            throw new NotImplementedException();
        }

        public Produto ObterPOrId(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
