using System.Collections.Generic;
using ToDo.Core.Data.Repositories;
using ToDo.Domain;

namespace ToDo.Core.Business.Services.Impl
{
    public class ObservacaoService : GenericService<Observacao, IObservacaoRepository>, IObservacaoService
    {
        public ObservacaoService(IObservacaoRepository repository)
            : base(repository)
        { }

        public List<Observacao> ListarPorTarefa(int id)
        {
            return _repository.ListarPorTarefa(id);
        }
    }
}
