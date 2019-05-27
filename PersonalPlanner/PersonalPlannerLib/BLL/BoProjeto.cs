using PersonalPlannerLib.DAL;
using PersonalPlannerLib.DML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalPlannerLib.BLL
{
    public class BoProjeto
    {
        public void Incluir(string pTitulo, int pCodUsuario, int pCodPai)
        {
            DispatcherProjeto dsp = new DispatcherProjeto();

            dsp.Incluir(pTitulo, pCodUsuario, pCodPai);
        }

        public Projeto Consultar(int pCodProjeto, int pCodUsuario)
        {
            DispatcherProjeto dsp = new DispatcherProjeto();

            return dsp.Consultar(pCodProjeto, pCodUsuario);
        }

        public List<Projeto> ConsultarPorUsuario(int pCodUsuario)
        {
            DispatcherProjeto dsp = new DispatcherProjeto();

            return dsp.ConsultarPorUsuario(pCodUsuario);
        }

        public List<Projeto> ConsultarPorProjetoPai(int pCodUsuario, int pCodProjetoPai)
        {
            DispatcherProjeto dsp = new DispatcherProjeto();

            return dsp.ConsultarPorProjetoPai(pCodUsuario, pCodProjetoPai);
        }
    }
}
