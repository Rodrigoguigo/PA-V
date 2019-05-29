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
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cadastro()
        {
            return View("Signin");
        }

        public ActionResult Cadastrar(UsuarioViewModel model)
        {
            BoUsuario boUsuario = new BoUsuario();

            if (boUsuario.ExisteUsuario(model.Login))
            {
                ViewBag.Message = "Usuario ja existente";
                return View("Signin");
            }
            else if (boUsuario.ExisteUsuario(model.Email))
            {
                ViewBag.Message = "Email ja cadastrado por outro usuario";
                return View("Signin");
            }
            else if (model.Senha != model.ConfirmarSenha)
            {
                ViewBag.Message = "Ambas as senhas precisam ser as mesmas";
                return View("Signin");
            }
            else
            {
                boUsuario.Incluir(model.Login, model.Email, model.Senha);
                return View("Index");
            }
        }

        public ActionResult Logar(UsuarioViewModel model)
        {
            BoUsuario boUsuario = new BoUsuario();

            if (boUsuario.IsUsuarioValido(model.Login, model.Senha))
            {
                Ambiente.UsuarioLogado = boUsuario.Consultar(model.Login);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "Usuario ou Senha incorretos";
                return View("Index");
            }
        }
    }
}