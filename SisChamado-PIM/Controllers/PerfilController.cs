using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CamadaDados;
using CamadaModelo;
namespace SisChamado_PIM.Controllers
{
    public class PerfilController : Controller
    {
        // GET: Perfil
        public ActionResult Index()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            DAL_Perfil dPerfil = new DAL_Perfil(MvcApplication.strConexao);
            var vLista = dPerfil.ListarPerfil(new Perfil());
            return View(vLista);
        }
    }
}