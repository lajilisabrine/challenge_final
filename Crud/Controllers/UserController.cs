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
        public Crud.Models.AppContext db { get; private set; }
        public UserController()
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
            Utilisateur utilisateur = Session["CurrentUser"] as Utilisateur;
            var Utilisateur = db.Utilisateurs.Find(utilisateur.Id);
            var ListeObjectif = Utilisateur.Objectifs.Where(x=>x.Status_Obj==Status_Obj.En_attente).ToList();
            if(ListeObjectif.Count()>0)
            {
                ViewBag.AnnerObj = ListeObjectif.FirstOrDefault().Annee;
            }
            return View(ListeObjectif);
        }
        [HttpPost]
        public JsonResult SaveObjectifSatut(int status, string commentaire, int anner)
        {
            Utilisateur utilisateur = Session["CurrentUser"] as Utilisateur;
            var Utilisateur = db.Utilisateurs.Find(utilisateur.Id);
            var ListeObjectif = Utilisateur.Objectifs.Where(x=>x.Annee== anner).ToList();
            var Status_Objectif = new Status_Obj();
            if (status == 1)
                Status_Objectif = Status_Obj.Valide;
            if (status == 2)
                Status_Objectif = Status_Obj.Reserve;

            foreach (var Objectif in ListeObjectif)
            {
                Objectif.Commantaire_Employee = commentaire;
                Objectif.Status_Obj = Status_Objectif;

                db.SaveChanges();
            }



            return Json("Sucess", JsonRequestBehavior.AllowGet);
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
