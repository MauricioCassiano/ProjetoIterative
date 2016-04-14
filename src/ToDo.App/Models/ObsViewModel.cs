using PagedList;
using System.Collections.Generic;
using System.Text;
using ToDo.Domain;

namespace ToDo.App.Models
{
    public class ObsViewModel
    {
            public int Id { get; set; }
            public List<Observacao> Observacoes { get; set; }
    }
}