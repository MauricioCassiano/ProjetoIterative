using System.Collections.Generic;
using ToDo.Core.Data.Repositories;
using ToDo.Domain;

namespace ToDo.Core.Business.Services
{
    public interface IGenericService<TEntity, TRepository>
        where TEntity : class, IClassModel
        where TRepository : class, IGenericRepository<TEntity>
    {
        List<TEntity> Listar();
        TEntity Pesquisar(int id);
        void Salvar(TEntity entity);
        bool Excluir(int id);
    }
}
