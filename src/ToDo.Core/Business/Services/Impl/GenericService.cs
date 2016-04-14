using System.Collections.Generic;
using ToDo.Core.Data.Repositories;
using ToDo.Domain;

namespace ToDo.Core.Business.Services.Impl
{
    public abstract class GenericService<TEntity, TRepository> : IGenericService<TEntity, TRepository>
        where TEntity : class, IClassModel
        where TRepository : class, IGenericRepository<TEntity>
    {
        protected readonly TRepository _repository;

        public GenericService(TRepository repository)
        {
            this._repository = repository;
        }

        public virtual List<TEntity> Listar()
        {
            return this._repository.Listar();
        }

        public virtual TEntity Pesquisar(int id)
        {
            return this._repository.Pesquisar(id);
        }

        public virtual void Salvar(TEntity entity)
        {
            if (entity.Id == 0)
                this._repository.Salvar(entity);
            else
                this._repository.Atualizar(entity);
        }

        public virtual bool Excluir(int id)
        {
            return this._repository.Excluir(id);
        }
    }
}
