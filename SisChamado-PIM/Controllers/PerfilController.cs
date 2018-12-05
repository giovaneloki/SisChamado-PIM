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

        [HttpGet]
        public PartialViewResult Add()
        {
            return PartialView();
        }

        [HttpPost]
        public bool Add(Perfil vPerfil)
        {
            return new DAL_Perfil(MvcApplication.strConexao).CadastrarPerfil(vPerfil);
        }

        [HttpGet]
        public PartialViewResult Edit(int idPerfil)
        {
            var perfil = new DAL_Perfil(MvcApplication.strConexao).ListarPerfil(new Perfil() { idPerfil = idPerfil }).FirstOrDefault();
            return PartialView(perfil);
        }

        [HttpPost]
        public bool Edit(Perfil vPerfil)
        {
            return new DAL_Perfil(MvcApplication.strConexao).AlterarPerfil(vPerfil);
        }

        [HttpPost]
        public bool Delete(int idPerfil)
        {
            return new DAL_Perfil(MvcApplication.strConexao).DeletarPerfil(new Perfil() { idPerfil = idPerfil });
        }
    }
}