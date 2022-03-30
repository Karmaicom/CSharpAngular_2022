using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaWeb.Infra.Data.Repositories
{
    public interface IBaseRepository<TEntity, TKey>
    {

        void Create(TEntity obj);

        void Update(TEntity obj);

        void Delete(TKey key);

        List<TEntity> FindAll();

        TEntity FindById(TKey key);

    }
}
