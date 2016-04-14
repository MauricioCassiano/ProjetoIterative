using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDo.Domain;

namespace ToDo.App.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Tarefa> FiltraTarefas { get; set; }
        public IPagedList<Tarefa> RelatorioTarefas { get; set; }
        public bool Concluido { get; set; }
        public bool Andamento { get; set; }
        public int PageNumber { get; set; }
    }
}