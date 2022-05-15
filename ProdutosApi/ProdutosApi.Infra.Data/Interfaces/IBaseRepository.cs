using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApi.Infra.Data.Interfaces
{
    public interface IBaseRepository<TEntity>
        where TEntity : class
    {

        void Inserir(TEntity entity);
        void Alterar(TEntity entity);
        void Delete(TEntity entity);

        List<TEntity> Consultar();
        TEntity ObterPOrId(Guid id);

    }
}
