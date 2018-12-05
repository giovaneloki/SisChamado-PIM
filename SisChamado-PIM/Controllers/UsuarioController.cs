using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CamadaDados;
using CamadaModelo;

namespace SisChamado_PIM.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            var vLista = new DAL_Usuario(MvcApplication.strConexao).ListarUsuario(new Usuario());
            return View(vLista);
        }

        [HttpGet]
        public PartialViewResult Add()
        {
            var vPerfil = new DAL_Perfil(MvcApplication.strConexao).ListarPerfil(new Perfil());
            return PartialView(vPerfil);
        }

        [HttpPost]
        public bool Add (Usuario vUsuario, Perfil vPerfil)
        {
            vUsuario.Perfil = vPerfil;
            return new DAL_Usuario(MvcApplication.strConexao).CadastrarUsuario(vUsuario);
        }


        [HttpGet]
        public PartialViewResult Edit(int idUsuario)
        {
            var vUsuario = new DAL_Usuario(MvcApplication.strConexao).BuscarPorLoginOuID(new Usuario() { idUsuario = idUsuario });
            var vPerfil = new DAL_Perfil(MvcApplication.strConexao).ListarPerfil(new Perfil());
            ViewBag.Perfil = vPerfil;
            return PartialView(vUsuario);
        }

        [HttpPost]
        public bool Edit(Usuario vUsuario, Perfil vPerfil)
        {
            vUsuario.Perfil = vPerfil;
            return new DAL_Usuario(MvcApplication.strConexao).AlterarUsuario(vUsuario);
        }

        [HttpPost]
        public bool Delete(int idUsuario)
        {
            return new DAL_Usuario(MvcApplication.strConexao).DesativarUsuario(new Usuario() { idUsuario = idUsuario });
        }
    }
}