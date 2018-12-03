using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CamadaDados;
using CamadaModelo;

namespace SisChamado_PIM.Controllers
{
    public class ChamadoController : Controller
    {
        // GET: Chamado
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult ListarChamadosAbertos()//int? idStatus, int? idSolicitante, int? idAtendente, int? idNivel, int? idTipo )
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            DAL_Chamado dChamado = new DAL_Chamado(MvcApplication.strConexao);
            return new JsonResult() { Data = dChamado.ListaChamados(new Chamado()), JsonRequestBehavior = JsonRequestBehavior.AllowGet, MaxJsonLength = Int32.MaxValue };
        }
    }
}