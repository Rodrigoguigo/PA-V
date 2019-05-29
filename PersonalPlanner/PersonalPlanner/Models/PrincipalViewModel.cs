using PersonalPlannerLib.DML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalPlanner.Models
{
    public class PrincipalViewModel
    {
        public ProjetoViewModel ProjetoModel { get; set; }

        public TarefaViewModel TarefaModel { get; set; }

        public List<Projeto> Projetos { get; set; }
    }
}