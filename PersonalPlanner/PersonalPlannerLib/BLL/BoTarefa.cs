using PersonalPlannerLib.DAL;
using PersonalPlannerLib.DML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalPlannerLib.BLL
{
    public class BoTarefa
    {
        public void Incluir(string pTitulo, string pDescricao, DateTime pDataEntrega, int pCodProjeto, int pCodUsuario)
        {
            DispatcherTarefa dsp = new DispatcherTarefa();

            dsp.Incluir(pTitulo, pDescricao, pDataEntrega, pCodProjeto, pCodUsuario);
        }

        public Tarefa Consultar(int pCodTarefa, int pCodUsuario)
        {
            DispatcherTarefa dsp = new DispatcherTarefa();

            return dsp.Consultar(pCodTarefa, pCodUsuario);
        }

        public List<Tarefa> ConsultarPorProjeto(int pCodProjeto, int pCodUsuario)
        {
            DispatcherTarefa dsp = new DispatcherTarefa();

            return dsp.ConsultarPorProjeto(pCodProjeto, pCodUsuario);
        }
    }
}
