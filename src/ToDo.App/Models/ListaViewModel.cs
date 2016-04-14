using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDo.App.Models
{
    public class ListaViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public bool Finalizado { get; set; }
        public string Data { get; set; }
    }
}