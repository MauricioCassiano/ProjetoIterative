using ToDo.Core.Data.Repositories;
using ToDo.Domain;

namespace ToDo.Core.Business.Services
{
    public interface ITarefaService : IGenericService<Tarefa,ITarefaRepository>
    {
        int SalvarTarefa(Tarefa tarefa);
    }
}
