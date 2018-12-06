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

        [HttpGet]
        public JsonResult ListarChamadosAbertos()//int? idStatus, int? idSolicitante, int? idAtendente, int? idTipo, int? idTipo )
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            DAL_Chamado dChamado = new DAL_Chamado(MvcApplication.strConexao);
            return new JsonResult() { Data = dChamado.ListaChamados(new Chamado()), JsonRequestBehavior = JsonRequestBehavior.AllowGet, MaxJsonLength = Int32.MaxValue };
        }

        [HttpGet]
        public JsonResult ChamadoPorId(int idChamado)//int? idStatus, int? idSolicitante, int? idAtendente, int? idTipo, int? idTipo )
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            DAL_Chamado dChamado = new DAL_Chamado(MvcApplication.strConexao);
            return new JsonResult() { Data = dChamado.ListaChamados(new Chamado() { idChamado = idChamado }), JsonRequestBehavior = JsonRequestBehavior.AllowGet, MaxJsonLength = Int32.MaxValue };
        }

        public PartialViewResult Add()
        {
            ViewBag.Nivel = new DAL_Nivel(MvcApplication.strConexao).ListarNivel(new Nivel());
            ViewBag.Tipo = new DAL_Tipo(MvcApplication.strConexao).ListarTipo(new Tipo());
            return PartialView();
        }

        [HttpPost]
        public bool Add(Chamado vChamado, Nivel vNivel, Tipo vTipo)
        {
            vChamado.Nivel = vNivel;
            vChamado.Tipo = vTipo;
            vChamado.Status.idStatus = new DAL_Status(MvcApplication.strConexao).ListarStatus(new Status()).FirstOrDefault().idStatus;
            vChamado.dataSolicitada = DateTime.Now;
            var usuario = (Usuario)Session["usuarioLogado"];
            vChamado.usuarioSolicitante.idUsuario = usuario.idUsuario;
            return new DAL_Chamado(MvcApplication.strConexao).CadastrarChamado(vChamado);
        }

        [HttpGet]
        public PartialViewResult Edit(int idChamado)
        {
            ViewBag.Nivel = new DAL_Nivel(MvcApplication.strConexao).ListarNivel(new Nivel());
            ViewBag.Tipo = new DAL_Tipo(MvcApplication.strConexao).ListarTipo(new Tipo());
            ViewBag.Status = new DAL_Status(MvcApplication.strConexao).ListarStatus(new Status());

            var vChamado = new DAL_Chamado(MvcApplication.strConexao).ChamadoPorID(new Chamado() { idChamado = idChamado });

            return PartialView(vChamado);
        }

        [HttpPost]
        public bool Edit(Chamado vChamado, Nivel vNivel, Tipo vTipo, Status vStatus, Usuario vSolicitante, Usuario vAtendimento)
        {
            vChamado.Nivel = vNivel;
            vChamado.Tipo = vTipo;
            vChamado.Status = vStatus;            
            var usuario = (Usuario)Session["usuarioLogado"];
            vChamado.usuarioSolicitante = vSolicitante;
            vChamado.usuarioAtendimento = new Usuario() { idUsuario = usuario.idUsuario }; ;

            return new DAL_Chamado(MvcApplication.strConexao).AlterarChamado(vChamado);
        }

        [HttpPost]
        public bool Delete(int idChamado)
        {
            return new DAL_Chamado(MvcApplication.strConexao).DeletarChamado(new Chamado() { idChamado = idChamado });
        }
    }
}