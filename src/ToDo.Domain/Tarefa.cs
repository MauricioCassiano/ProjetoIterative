using System;
using System.Collections.Generic;

namespace ToDo.Domain
{
    public class Tarefa : ClassModel
    {

        #region Public Properties 

        public string Titulo { get; set; }
        public DateTime? Date { get; set; }
        public bool Finalizado { get; set; }
        public virtual List<Observacao> Observacoes { get; set; }

        #endregion

        #region Contructors

        public Tarefa()
            : this(0)
        { }

        public Tarefa(int id)
        {
            this.Id = id;
            this.Date = DateTime.Now;
        }
        #endregion
    }
}
