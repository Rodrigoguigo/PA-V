using PersonalPlannerLib.DML;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalPlannerLib.DAL
{
    class DispatcherTarefa : DispatcherBase
    {
        private const string SP_INCLUIR_TAREFA = "SP_IncTarefa";

        private const string SP_CONSULTAR_TAREFA = "SP_SelTarefa";

        private const string SP_CONSULTAR_TAREFA_POR_PROJETO = "SP_SelTarefaProjeto";

        public void Incluir(string pTitulo, string pDescricao, DateTime pDataEntrega, int pCodProjeto, int pCodUsuario)
        {
            SqlDataReader retorno = ExecutarProcedure(SP_INCLUIR_TAREFA, new object[] { pTitulo, pDescricao, pDataEntrega.ToString(), pCodProjeto.ToString(), pCodUsuario.ToString() });
        }

        public Tarefa Consultar(int pCodTarefa, int pCodUsuario)
        {
            Tarefa tarefa = new Tarefa();
            SqlDataReader retorno = ExecutarProcedure(SP_CONSULTAR_TAREFA, new object[] { pCodTarefa.ToString(), pCodUsuario.ToString() });

            if (retorno.HasRows)
            {
                if (retorno["TarefaID"] != DBNull.Value)
                    tarefa.Codigo = int.TryParse(retorno["TarefaID"].ToString(), out int res) ? res : 0;
                if (retorno["Titulo"] != DBNull.Value)
                    tarefa.Titulo = retorno["Titulo"].ToString();
                if (retorno["Descricao"] != DBNull.Value)
                    tarefa.Descricao = retorno["Descricao"].ToString();
                if (retorno["DataEntrega"] != DBNull.Value)
                    tarefa.DataEntrega = DateTime.TryParse(retorno["Descricao"].ToString(), out DateTime res) ? res : DateTime.MinValue;
                if (retorno["ProjetoID"] != DBNull.Value)
                    tarefa.ProjetoId = int.TryParse(retorno["ProjetoID"].ToString(), out int res) ? res : 0;
            }

            return tarefa;
        }

        public List<Tarefa> ConsultarPorProjeto(int pCodProjeto, int pCodUsuario)
        {
            List<Tarefa> tarefas = new List<Tarefa>();
            SqlDataReader retorno = ExecutarProcedure(SP_CONSULTAR_TAREFA_POR_PROJETO, new object[] { pCodProjeto.ToString(), pCodUsuario.ToString() });

            while (retorno.Read())
            {
                Tarefa tarefa = new Tarefa();

                if (retorno["TarefaID"] != DBNull.Value)
                    tarefa.Codigo = int.TryParse(retorno["TarefaID"].ToString(), out int res) ? res : 0;
                if (retorno["Titulo"] != DBNull.Value)
                    tarefa.Titulo = retorno["Titulo"].ToString();
                if (retorno["Descricao"] != DBNull.Value)
                    tarefa.Descricao = retorno["Descricao"].ToString();
                if (retorno["DataEntrega"] != DBNull.Value)
                    tarefa.DataEntrega = DateTime.TryParse(retorno["Descricao"].ToString(), out DateTime res) ? res : DateTime.MinValue;
                if (retorno["ProjetoID"] != DBNull.Value)
                    tarefa.ProjetoId = int.TryParse(retorno["ProjetoID"].ToString(), out int res) ? res : 0;

                tarefas.Add(tarefa);
            }

            return tarefas;
        }
    }
}
