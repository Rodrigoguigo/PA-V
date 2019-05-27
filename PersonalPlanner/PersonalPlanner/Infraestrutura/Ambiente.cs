using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonalPlannerLib.DML;

namespace PersonalPlanner.Infraestrutura
{
    public class Ambiente
    {
        public static Usuario UsuarioLogado {
            get
            {
                if (UsuarioLogado == null)
                    return new Usuario();
                return UsuarioLogado;
            }
            set
            {
                UsuarioLogado = value;
            }
        }
    }
}