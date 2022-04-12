using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApi.Infra.Data.Interfaces
{
    public interface IBaseRepository<TEntity, TKey>
        where TEntity : class
    {

        void Inserir(TEntity obj);
        void Excluir(TEntity obj);
        void Alterar(TEntity obj);
        List<TEntity> Consultar();
        TEntity ObterPorId(Guid id);

    }
}
