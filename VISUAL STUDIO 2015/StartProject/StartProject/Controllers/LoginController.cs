using StartProject.DAO;
using StartProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StartProject.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Autentica(string login,string senha)
        {
            var dao = new UsuariosDAO();
            Usuario user = dao.Busca(login, senha);

            if (user != null)
            {
                Session["usuarioLogado"] = user;
                return RedirectToAction("index", "Produto");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }


}