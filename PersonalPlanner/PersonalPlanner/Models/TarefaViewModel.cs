using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalPlanner.Models
{
    public class TarefaViewModel
    {
        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public DateTime DataEntrega { get; set; }

        public int ProjetoId { get; set; }
    }
}