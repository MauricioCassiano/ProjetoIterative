using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ToDo.Domain;

namespace ToDo.Core.Data.Repositories.Impl
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class, IClassModel
    {
        protected readonly DbContext _context;

        public GenericRepository(DbContext context)
        {
            this._context = context;
        }

        public virtual List<TEntity> Listar()
        {
            return this._context.Set<TEntity>().ToList();
        }

        public virtual TEntity Pesquisar(int id)
        {
            return this._context.Set<TEntity>().Find(id);
        }

        public virtual void Salvar(TEntity entity)
        {
            this._context.Set<TEntity>().Add(entity);
            this._context.SaveChanges();
        }

        public virtual bool Atualizar(TEntity entity)
        {
            var atual = this._context.Set<TEntity>().Find(entity.Id);

            if (atual != null)
            {
                this._context.Entry(atual).CurrentValues.SetValues(entity);
                this._context.SaveChanges();
            }

            return true;
        }

        public virtual bool Excluir(int id)
        {
            var entity = this._context.Set<TEntity>().Find(id);

            this._context.Set<TEntity>().Remove(entity);
            this._context.SaveChanges();

            return true;
        }
    }
}