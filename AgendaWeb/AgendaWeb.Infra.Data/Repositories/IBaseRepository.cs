﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaWeb.Infra.Data.Repositories
{
    public interface IBaseRepository<TEntity>
        where TEntity : class
    {

        void Create(TEntity obj);

        void Update(TEntity obj);

        void Delete(TEntity obj);

        List<TEntity> FindAll();

        TEntity FindById(Guid id);

    }
}
