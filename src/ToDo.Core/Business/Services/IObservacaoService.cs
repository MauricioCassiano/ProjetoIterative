using System.Collections.Generic;
using ToDo.Core.Data.Repositories;
using ToDo.Domain;

namespace ToDo.Core.Business.Services
{
    public interface IObservacaoService : IGenericService<Observacao, IObservacaoRepository>
    {
        List<Observacao> ListarPorTarefa(int id);
    }
}
