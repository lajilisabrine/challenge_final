using Crud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crud.Controllers
{
    public class ManagerController : Controller
    {
        public Crud.Models.AppContext db { get; private set; }
        public ManagerController()
        {
            db = new Crud.Models.AppContext();
        }
        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            if (Session["CurrentUser"] == null)
            {
                RedirectToAction("login", "shared").ExecuteResult(this.ControllerContext);
            }
        }
        // GET: Manager
        public ActionResult Index()
        {
            return View();
        }
        
             public ActionResult monprofil()
        {
            return View();
        }
        [HttpPost]
        public JsonResult SaveObjectif(List<Objectif> objectifs ,int CodeUtilisateur)
        {
            var Utilisateur = db.Utilisateurs.Find(CodeUtilisateur);
            Utilisateur.Objectifs.AddRange(objectifs);
            db.SaveChanges();



            return Json("Sucess", JsonRequestBehavior.AllowGet);
        }
        public ActionResult ListeCollaborateurs()
        {
            var CurrentUser = Session["CurrentUser"] as Utilisateur;

            var ListeCollaborateurs = db.Utilisateurs.Where(x => x.Manager.Equals(CurrentUser.Matricule)).ToList();
            return View(ListeCollaborateurs);
        }
        public ActionResult Entretienencours()
        {
            return View();
        }
        
        public ActionResult demandeFormations()
        {
            return View();
        }
        
              public ActionResult historiqueEquipe()
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