using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Crud.Models;

namespace Crud.Controllers
{
    public class UserController : Controller
    {
        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            if (Session["CurrentUser"] == null)
            {
                RedirectToAction("login", "shared").ExecuteResult(this.ControllerContext);
            }
        }
        public ActionResult index()
        {
            return View();
        }
        
            public ActionResult monprofil()
        {
            return View();
        }
        public ActionResult demandeFormations()
        {
            Utilisateur utilisateur = Session["CurrentUser"] as Utilisateur;
            ViewBag.Matricule = utilisateur.Matricule;
            return View();
        }
        public ActionResult Entretienencours()
        {
            return View();
        }
        public ActionResult monhistorique()
        {
            return View();
        }
        public ActionResult demandeTICKETS()
        {
            return View();
        }
    }
}
