using System.Collections.Generic;
using ToDo.Domain;

namespace ToDo.Core.Data.Repositories
{
    public interface IGenericRepository<TEntity>
    where TEntity : class, IClassModel
    {
        List<TEntity> Listar();
        TEntity Pesquisar(int id);
        void Salvar(TEntity entity);
        bool Atualizar(TEntity entity);
        bool Excluir(int id);
    }
}
