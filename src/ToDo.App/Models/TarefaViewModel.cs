using System.ComponentModel.DataAnnotations;

namespace ToDo.App.Models
{
    public class TarefaViewModel
    {
        public int IdTarefa { get; set; }
        public string Titulo { get; set; }
        public bool Finalizado { get; set; }

        [Required(ErrorMessage = "O campo observação é obrigatorio.")]
        public string Observacao { get; set; }
    }
}