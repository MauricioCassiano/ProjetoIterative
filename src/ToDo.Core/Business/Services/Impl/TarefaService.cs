using ToDo.Core.Data.Repositories;
using ToDo.Domain;

namespace ToDo.Core.Business.Services.Impl
{
    public class TarefaService : GenericService<Tarefa,ITarefaRepository>, ITarefaService
    {
        public TarefaService(ITarefaRepository repository)
            :base(repository)
        { }

        public int SalvarTarefa(Tarefa tarefa)
        {
            return _repository.SalvarTarefa(tarefa);
        }
    }
}
