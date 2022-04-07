﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosWeb.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity>
    {

        void Inserir(TEntity entity);
        void Alterar(TEntity entity);
        void Excluir(TEntity entity);
        List<TEntity> Consultar();
        TEntity ObterPorId(Guid id);

    }
}
