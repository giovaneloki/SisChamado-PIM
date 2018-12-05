using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CamadaDados;
using CamadaModelo;

namespace SisChamado_PIM.Controllers
{
    public class StatusController : Controller
    {
        // GET: Status
        public ActionResult Index()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            DAL_Status dStatus = new DAL_Status(MvcApplication.strConexao);
            var vLista = dStatus.ListarStatus(new Status());
            return View(vLista);
        }

        [HttpGet]
        public PartialViewResult Add()
        {
            return PartialView();
        }

        [HttpPost]
        public bool Add(Status vStatus)
        {
            return new DAL_Status(MvcApplication.strConexao).CadastrarStatus(vStatus);
        }

        [HttpGet]
        public PartialViewResult Edit(int idStatus)
        {
            var Status = new DAL_Status(MvcApplication.strConexao).ListarStatus(new Status() { idStatus = idStatus }).FirstOrDefault();
            return PartialView(Status);
        }

        [HttpPost]
        public bool Edit(Status vStatus)
        {
            return new DAL_Status(MvcApplication.strConexao).AlterarStatus(vStatus);
        }

        [HttpPost]
        public bool Delete(int idStatus)
        {
            return new DAL_Status(MvcApplication.strConexao).DeletarStatus(new Status() { idStatus = idStatus });
        }
    }
}