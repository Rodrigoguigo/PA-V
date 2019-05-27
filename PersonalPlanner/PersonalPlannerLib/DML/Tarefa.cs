using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalPlannerLib.DML
{
    public class Tarefa
    {
        public int Codigo { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public DateTime DataEntrega { get; set; }

        public int ProjetoId { get; set; }
    }
}
