using ToDo.Domain;

namespace ToDo.Core.Data.Repositories
{
    public interface ITarefaRepository : IGenericRepository<Tarefa>
    {
        int SalvarTarefa(Tarefa tarefa);
    }
}
