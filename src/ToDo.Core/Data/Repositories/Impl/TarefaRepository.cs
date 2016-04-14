using System.Data.Entity;
using ToDo.Domain;

namespace ToDo.Core.Data.Repositories.Impl
{
    public class TarefaRepository : GenericRepository<Tarefa>, ITarefaRepository
    {
        public TarefaRepository(DbContext context)
            : base(context)
        { }

        public int SalvarTarefa(Tarefa tarefa)
        {
            this._context.Set<Tarefa>().Add(tarefa);
            this._context.SaveChanges();

            return tarefa.Id;
        }
    }
}
