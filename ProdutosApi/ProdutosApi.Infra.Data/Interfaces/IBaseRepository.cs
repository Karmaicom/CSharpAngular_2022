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

        void Inerir(TEntity entity);
        void Alterar(TEntity entity);
        void Excluir(TEntity entity);

        List<TEntity> Consultar();
        TEntity ObterPOrId(Guid id);

    }
}
