using PersonalPlanner.Infraestrutura;
using PersonalPlanner.Models;
using PersonalPlannerLib.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalPlanner.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult CadastrarTarefa(TarefaViewModel model)
        {
            BoTarefa boTarefa = new BoTarefa();

            boTarefa.Incluir(model.Titulo, model.Descricao, model.DataEntrega, model.ProjetoId, Ambiente.UsuarioLogado.Codigo);

            ViewBag.Message = "Tarefa cadastrada com sucesso";

            return Index();
        }

        public ActionResult CadastrarProjeto(ProjetoViewModel model)
        {
            BoProjeto boProjeto = new BoProjeto();

            boProjeto.Incluir(model.Titulo, Ambiente.UsuarioLogado.Codigo, model.ProjetoPai);

            ViewBag.Message = "Projeto cadastrado com sucesso";

            return Index();
        }
    }
}