using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ToDo.Domain;

namespace ToDo.Core.Data.Repositories.Impl
{
    public class ObservacaoRepository : GenericRepository<Observacao>, IObservacaoRepository
    {
        public ObservacaoRepository(DbContext context)
            : base(context)
        { }

        public List<Observacao> ListarPorTarefa(int id)
        {
            return this._context.Set<Observacao>().Where(o => o.IdTarefa == id).ToList();
        }
    }
}
