using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CamadaDados;
using CamadaModelo;

namespace SisChamado_PIM.Controllers
{
    public class HomeController : Controller
    {
        public string strConexao = MvcApplication.strConexao;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Logar(string login, string senha)
        {
            Usuario vUsuario = new Usuario();
            DAL_Usuario dUsuario = new DAL_Usuario(strConexao);

            vUsuario.loginUsuario = login;
            vUsuario.senhaUsuario = senha;

            try
            {
                vUsuario = dUsuario.LogarUsuario(vUsuario);
                if (vUsuario.idUsuario == 0)
                {
                    return Redirect("../Home/ErroLogin");
                }
                else
                {
                    Session["usuarioLogado"] = vUsuario;
                    if(vUsuario.Perfil.idPerfil == 1)
                    {
                        return Redirect("../Home/Tecnico");
                    }
                    else
                    {
                        return Redirect("../Home/Usuario");
                    }
                }
            }
            catch(Exception ex)
            {
                return Redirect("../Home/ErroLogin");
            }
        }

        public ActionResult ErroLogin()
        {
            return View();
        }

        public ActionResult Tecnico()
        {
            var usuario = (Usuario)Session["usuarioLogado"];
            if (usuario.idUsuario > 0 && usuario.Perfil.idPerfil == 1)
            {
                return View();
            }
            else
            {
                return Redirect("../Home/Index");
            }
        }

        public ActionResult Usuario()
        {
            var usuario = (Usuario)Session["usuarioLogado"];
            if (usuario.idUsuario > 0 && usuario.Perfil.idPerfil == 2)
            {
                return View();
            }
            else
            {
                return Redirect("../Home/Index");
            }
        }

        public ActionResult Redirecionar()
        {
            var usuario = (Usuario)Session["usuarioLogado"];
            if (usuario.Perfil.idPerfil == 1)
            {
                return Redirect("../Home/Tecnico");
            }
            else
            {
                return Redirect("../Home/Usuario");
            }
        }

        [HttpGet]
        public JsonResult ListarPorUsuario()
        {
            Usuario vUsuario = (Usuario)Session["usuarioLogado"];
            var vLista = new DAL_Chamado(MvcApplication.strConexao).ListaChamados(new Chamado());

            return new JsonResult() { Data = vLista.Where(c => (c.usuarioSolicitante.idUsuario == vUsuario.idUsuario)), JsonRequestBehavior = JsonRequestBehavior.AllowGet, MaxJsonLength = Int32.MaxValue };
        }
    }
}