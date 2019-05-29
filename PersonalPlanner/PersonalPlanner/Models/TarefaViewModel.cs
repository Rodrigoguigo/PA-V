using PersonalPlanner.Infraestrutura;
using PersonalPlannerLib.BLL;
using PersonalPlannerLib.DML;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalPlanner.Models
{
    public class TarefaViewModel
    {
        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public DateTime DataEntrega { get; set; }

        public int ProjetoId { get; set; }

        public SelectList Projetos { get; set; }

        public TarefaViewModel()
        {
            List<Projeto> projetos = new BoProjeto().ConsultarPorUsuario(Ambiente.UsuarioLogado.Codigo, true);
            projetos.Insert(0, new Projeto { Codigo = 0, ProjetoPai = 0, Titulo = "Nenhum" });
            Projetos = new SelectList(projetos, "Codigo", "Titulo");
        }
    }
}