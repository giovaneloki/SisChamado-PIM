using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CamadaDados;
using CamadaModelo;

namespace SisChamado_PIM.Controllers
{
    public class TipoController : Controller
    {
        // GET: Tipo
        public ActionResult Index()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            DAL_Tipo dTipo = new DAL_Tipo(MvcApplication.strConexao);
            var vLista = dTipo.ListarTipo(new Tipo());
            return View(vLista);
        }

        [HttpGet]
        public PartialViewResult Add()
        {
            return PartialView();
        }

        [HttpPost]
        public bool Add(Tipo vTipo)
        {
            return new DAL_Tipo(MvcApplication.strConexao).CadastrarTipo(vTipo);
        }

        [HttpGet]
        public PartialViewResult Edit(int idTipo)
        {
            var Tipo = new DAL_Tipo(MvcApplication.strConexao).ListarTipo(new Tipo() { idTipo = idTipo }).FirstOrDefault();
            return PartialView(Tipo);
        }

        [HttpPost]
        public bool Edit(Tipo vTipo)
        {
            return new DAL_Tipo(MvcApplication.strConexao).AlterarTipo(vTipo);
        }

        [HttpPost]
        public bool Delete(int idTipo)
        {
            return new DAL_Tipo(MvcApplication.strConexao).DeletarTipo(new Tipo() { idTipo = idTipo });
        }
    }
}