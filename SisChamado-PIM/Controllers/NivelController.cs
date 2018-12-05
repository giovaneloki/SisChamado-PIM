using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CamadaDados;
using CamadaModelo;

namespace SisChamado_PIM.Controllers
{
    public class NivelController : Controller
    {
        // GET: Nivel
        public ActionResult Index()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            DAL_Nivel dNivel = new DAL_Nivel(MvcApplication.strConexao);
            var vLista = dNivel.ListarNivel(new Nivel());
            return View(vLista);
        }

        [HttpGet]
        public PartialViewResult Add()
        {
            return PartialView();
        }

        [HttpPost]
        public bool Add(Nivel vNivel)
        {
            return new DAL_Nivel(MvcApplication.strConexao).CadastrarNivel(vNivel);
        }

        [HttpGet]
        public PartialViewResult Edit(int idNivel)
        {
            var Nivel = new DAL_Nivel(MvcApplication.strConexao).ListarNivel(new Nivel() { idNivel = idNivel }).FirstOrDefault();
            return PartialView(Nivel);
        }

        [HttpPost]
        public bool Edit(Nivel vNivel)
        {
            return new DAL_Nivel(MvcApplication.strConexao).AlterarNivel(vNivel);
        }

        [HttpPost]
        public bool Delete(int idNivel)
        {
            return new DAL_Nivel(MvcApplication.strConexao).DeletarNivel(new Nivel() { idNivel = idNivel });
        }
    }
}