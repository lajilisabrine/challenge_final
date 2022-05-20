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
            if (Utilisateur.Objectifs == null || Utilisateur.Objectifs.Count == 0)
                Utilisateur.Objectifs.AddRange(objectifs);
            else
            {
                List<Objectif> ObjUtilisateur = new List<Objectif>();
                ObjUtilisateur=Utilisateur.Objectifs.ToList();
                foreach (var obj in ObjUtilisateur.ToList())
                {
                    //Utilisateur.Objectifs.Remove(obj);
                    var objecct= db.Objectifs.Find(obj.Id);
                    db.Objectifs.Remove(objecct);
                    db.SaveChanges();
                }
                Utilisateur.Objectifs.AddRange(objectifs);
                db.SaveChanges();
            }
                

            db.SaveChanges();



            return Json("Sucess", JsonRequestBehavior.AllowGet);
        }
        public JsonResult Saveuserevaluation(Entretein Entretein)
        {
            //var Utilisateur = db.Utilisateurs.Find(CodeUtilisateur);

            //if (Utilisateur.Objectifs == null || Utilisateur.Objectifs.Count == 0)
            //    Utilisateur.Objectifs.AddRange(objectifs);
            //else
            //{
            //    List<Objectif> ObjUtilisateur = new List<Objectif>();
            //    ObjUtilisateur = Utilisateur.Objectifs.ToList();
            //    foreach (var obj in ObjUtilisateur.ToList())
            //    {
            //        //Utilisateur.Objectifs.Remove(obj);
            //        var objecct = db.Objectifs.Find(obj.Id);
            //        db.Objectifs.Remove(objecct);
            //        db.SaveChanges();
            //    }
            //    Utilisateur.Objectifs.AddRange(objectifs);
            //    db.SaveChanges();
            //}

            db.Entreteins.Add(Entretein);
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
        public JsonResult Passevaluation(int CodeUtilisateur)
        {
            var Utilisateur = db.Utilisateurs.Find(CodeUtilisateur);
           var ListObjectifs= Utilisateur.Objectifs;
            if (ListObjectifs.Count()==0)
            {
                return Json(new { Resultat = "Failed", Enattente = true, ListObjectifs = ListObjectifs }, JsonRequestBehavior.AllowGet);
            
            
            
            }
            else if(ListObjectifs != null && ListObjectifs.Any(x=>x.Status_Obj==Status_Obj.Reserve))
            {
                return Json(new { Resultat = "Failed", Enattente = true, ListObjectifs = ListObjectifs }, JsonRequestBehavior.AllowGet);
               
            }
            else
            {
                var Enattente = ListObjectifs.Any(x => x.Status_Obj == Status_Obj.En_attente);
                return Json(new { Resultat = "Sucess",Enattente= Enattente, ListObjectifs = ListObjectifs }, JsonRequestBehavior.AllowGet);
           
            }



           
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