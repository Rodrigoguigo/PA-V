using PersonalPlannerLib.DML;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalPlannerLib.DAL
{
    class DispatcherProjeto : DispatcherBase
    {
        private const string SP_INCLUIR_PROJETO = "SP_IncProjeto";

        private const string SP_CONSULTAR_PROJETO = "SP_SelProjeto";

        private const string SP_CONSULTAR_PROJETOS_POR_USUARIO = "SP_SelProjetoUsuario";

        private const string SP_CONSULTAR_PROJETOS_FILHOS = "SP_SelProjetosFilhos";

        public void Incluir(string pTitulo, int pCodUsuario, int pCodPai)
        {
            SqlDataReader retorno = ExecutarProcedure(SP_INCLUIR_PROJETO, new object[] { pTitulo, pCodUsuario.ToString(), (pCodPai > 0) ? pCodPai.ToString() : null });
        }

        public Projeto Consultar(int pCodProjeto, int pCodUsuario)
        {
            Projeto projeto = new Projeto();
            SqlDataReader retorno = ExecutarProcedure(SP_CONSULTAR_PROJETO, new object[] { pCodProjeto.ToString(), pCodUsuario.ToString() });

            if (retorno.HasRows)
            {
                if (retorno["ProjetoID"] != DBNull.Value)
                    projeto.Codigo = int.TryParse(retorno["ProjetoID"].ToString(), out int res) ? res : 0;
                if (retorno["Titulo"] != DBNull.Value)
                    projeto.Titulo = retorno["Titulo"].ToString();
                if (retorno["ProjetoPai"] != DBNull.Value)
                    projeto.ProjetoPai = int.TryParse(retorno["ProjetoPai"].ToString(), out int res) ? res : 0;
            }

            return projeto;
        }

        public List<Projeto> ConsultarPorUsuario(int pCodUsuario)
        {
            List<Projeto> projetos = new List<Projeto>();
            SqlDataReader retorno = ExecutarProcedure(SP_CONSULTAR_PROJETOS_POR_USUARIO, new object[] { pCodUsuario.ToString() });

            while (retorno.Read())
            {
                Projeto projeto = new Projeto();
                if (retorno["ProjetoID"] != DBNull.Value)
                    projeto.Codigo = int.TryParse(retorno["ProjetoID"].ToString(), out int res) ? res : 0;
                if (retorno["Titulo"] != DBNull.Value)
                    projeto.Titulo = retorno["Titulo"].ToString();
                if (retorno["ProjetoPai"] != DBNull.Value)
                    projeto.ProjetoPai = int.TryParse(retorno["ProjetoPai"].ToString(), out int res) ? res : 0;

                projetos.Add(projeto);
            }

            return projetos;
        }

        public List<Projeto> ConsultarPorProjetoPai(int pCodUsuario, int pCodProjetoPai)
        {
            List<Projeto> projetos = new List<Projeto>();
            SqlDataReader retorno = ExecutarProcedure(SP_CONSULTAR_PROJETOS_FILHOS, new object[] { pCodUsuario.ToString(), pCodProjetoPai.ToString() });

            while (retorno.Read())
            {
                Projeto projeto = new Projeto();
                if (retorno["ProjetoID"] != DBNull.Value)
                    projeto.Codigo = int.TryParse(retorno["ProjetoID"].ToString(), out int res) ? res : 0;
                if (retorno["Titulo"] != DBNull.Value)
                    projeto.Titulo = retorno["Titulo"].ToString();
                if (retorno["ProjetoPai"] != DBNull.Value)
                    projeto.ProjetoPai = int.TryParse(retorno["ProjetoPai"].ToString(), out int res) ? res : 0;

                projetos.Add(projeto);
            }

            return projetos;
        }
    }
}
