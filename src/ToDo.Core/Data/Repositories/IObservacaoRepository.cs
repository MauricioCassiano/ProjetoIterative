using System.Collections.Generic;
using ToDo.Domain;

namespace ToDo.Core.Data.Repositories
{
    public interface IObservacaoRepository : IGenericRepository<Observacao>
    {
        List<Observacao> ListarPorTarefa(int id);
    }
}
