using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonalPlannerLib.DML;

namespace PersonalPlanner.Infraestrutura
{
    public class Ambiente
    {
        private static Usuario usuarioLogado;

        public static Usuario UsuarioLogado {
            get
            {
                if (usuarioLogado == null)
                    return new Usuario();
                return usuarioLogado;
            }
            set
            {
                usuarioLogado = value;
            }
        }
    }
}