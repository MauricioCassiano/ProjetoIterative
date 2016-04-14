using System;

namespace ToDo.Domain
{
    public class Observacao : ClassModel
    {
        #region Public Properties

        public int IdTarefa { get; set; }
        public DateTime? Date { get; set; }
        public string Descricao { get; set; }

        #endregion

        #region Contructors

        public Observacao()
            : this(0, null)
        { }

        public Observacao(int idTarefa, string descricao)
        {
            this.IdTarefa = idTarefa;
            this.Descricao = descricao;
            this.Date = DateTime.Now;
        }
        #endregion
    }
}
