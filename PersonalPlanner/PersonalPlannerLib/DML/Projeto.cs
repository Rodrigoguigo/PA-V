using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalPlannerLib.DML
{
    public class Projeto
    {
        public int Codigo { get; set; }

        public string Titulo { get; set; }

        public int ProjetoPai { get; set; }
    }
}
