using Crud.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
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
           // var Utilisateur = db.Utilisateurs.Find(CodeUtilisateur);
            //if (Utilisateur.Objectifs == null || Utilisateur.Objectifs.Count == 0)
            //    Utilisateur.Objectifs.AddRange(objectifs);
            //else
            //{
            //    List<Objectif> ObjUtilisateur = new List<Objectif>();
            //    ObjUtilisateur=Utilisateur.Objectifs.ToList();
            //    foreach (var obj in ObjUtilisateur.ToList())
            //    {
            //        //Utilisateur.Objectifs.Remove(obj);
            //        var objecct= db.Objectifs.Find(obj.Id);
            //        db.Objectifs.Remove(objecct);
            //        db.SaveChanges();
            //    }
            //    Utilisateur.Objectifs.AddRange(objectifs);
            //    db.SaveChanges();
            //}


            //db.SaveChanges();

            var Utilisateur = db.Utilisateurs.Find(CodeUtilisateur);
            var Existe = db.Entreteins.Any(x => x.Utilisateur.Id == Utilisateur.Id);
            if (!Existe) { 
               Entretein Entretein = new Entretein();
               Entretein.Utilisateur = Utilisateur;
               Entretein.Objectifs = new List<Objectif>();            
               Entretein.Objectifs.AddRange(objectifs);
               Entretein.Année = DateTime.Now.Year;
               Entretein.Etat = Etat.Fixation_des_Objectifs;
               db.Entreteins.Add(Entretein);
               db.SaveChanges();
                Task.Run(() => SendMail(Utilisateur.Email, "Compte -Challenge", $"Bonjour {Utilisateur.FullName},{Environment.NewLine}Vos objectifs sont crées par votre Manager , Merci de consulter votre platforme.{Environment.NewLine}Cordialement,{Environment.NewLine}Équipe Challenge"));
                return Json("Sucess", JsonRequestBehavior.AllowGet);
            }
            else
            {

                var entretien = db.Entreteins.FirstOrDefault(x => x.Utilisateur.Id == Utilisateur.Id);
             var   ObjUtilisateur = entretien.Objectifs.ToList();
                foreach (var obj in ObjUtilisateur.ToList())
                {
                    
                    var objecct = db.Objectifs.Find(obj.Id);
                    db.Objectifs.Remove(objecct);
                    db.SaveChanges();
                }
                entretien.Objectifs.AddRange(objectifs);
                db.SaveChanges();
                Task.Run(() => SendMail(Utilisateur.Email, "Compte -Challenge", $"Bonjour {Utilisateur.FullName},{Environment.NewLine}Vos objectifs sont modifier  par votre Manager , Merci de consulter votre platforme.{Environment.NewLine}Cordialement,{Environment.NewLine}Équipe Challenge"));
                return Json("Sucess", JsonRequestBehavior.AllowGet);

            }



         
        }
        [HttpPost]
        public JsonResult Saveuserevaluation(Entretein Entretein, List<Objectif> objectifs, int CodeUtilisateur)
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
            var Utilisateur = db.Utilisateurs.Find(CodeUtilisateur);
            var entretien = db.Entreteins.FirstOrDefault(x => x.Utilisateur.Id == Utilisateur.Id);
            entretien.PointForts = Entretein.PointForts;
            entretien.Freins_Rencontres = Entretein.Freins_Rencontres;
            entretien.Année = Entretein.Année;
            entretien.Note = Entretein.Note;
            entretien.Etat = Etat.Evaluation;
            entretien.Appreciation = Entretein.Appreciation;
            entretien.Commantaire_Manager = Entretein.Commantaire_Manager;





            var ObjUtilisateur = entretien.Objectifs.ToList();
            foreach (var obj in ObjUtilisateur.ToList())
            {

                var objecct = db.Objectifs.Find(obj.Id);
                db.Objectifs.Remove(objecct);
                db.SaveChanges();
            }
            entretien.Objectifs.AddRange(objectifs);
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
      
          //  if (Existe) { }
           var Entreteindb = db.Entreteins.Where(x=>x.Utilisateur.Id== Utilisateur.Id).FirstOrDefault();

        
            if (Entreteindb ==null)
            {
             

                return Json(new { Resultat = "Failed", Enattente = true, ListObjectifs = "" }, JsonRequestBehavior.AllowGet);
            
            
            
            }
            else if(Entreteindb != null && Entreteindb.Objectifs != null && Entreteindb.Objectifs.Any(x=>x.Status_Obj==Status_Obj.Reserve)&& Entreteindb.Etat!=Etat.Evaluation)
            {
                var ListObjectifs = Entreteindb.Objectifs.Select(x => new
                {
                    Id = x.Id,
                    KPI = x.KPI,
                    Ponderation = x.Ponderation,
                    Titre_Obj = x.Titre_Obj,
                    Commantaire_Manager = x.Commantaire_Manager,
                    Status_Obj = x.Status_Obj,
                    Annee = x.Annee,
                    Ressultat = x.Ressultat,
                    Score = x.Score,
                }).ToList();
                return Json(new { Resultat = "Failed", Enattente = true, ListObjectifs = ListObjectifs, Etat = Entreteindb.Etat , EtatReserve=false}, JsonRequestBehavior.AllowGet);
               
            }
            else
            {
                var ListObjectifs = Entreteindb.Objectifs.Select(x => new
                {
                    Id = x.Id,
                    KPI = x.KPI,
                    Ponderation = x.Ponderation,
                    Titre_Obj = x.Titre_Obj,
                    Commantaire_Manager = x.Commantaire_Manager,
                    Status_Obj = x.Status_Obj,
                    Annee = x.Annee,
                    Ressultat=x.Ressultat,
                    Score=x.Score,
                }).ToList();
                
                var Enattente = ListObjectifs.Any(x => x.Status_Obj == Status_Obj.En_attente);
                var EtatReserve = ListObjectifs.Any(x => x.Status_Obj == Status_Obj.Reserve);
                return Json(new { Resultat = "Sucess",Enattente= Enattente, ListObjectifs = ListObjectifs, PointForts = Entreteindb.PointForts, Freins_recontre = Entreteindb.Freins_Rencontres, Note = Entreteindb.Note, Appreciation = Entreteindb.Appreciation, Cmt_empolyee = Entreteindb.Commantaire_Employee,
                    cmt_manager = Entreteindb.Commantaire_Manager,
                    Etat = Entreteindb.Etat ,
                    EtatReserve
                }, JsonRequestBehavior.AllowGet);
           
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
        public static void SendMail(String destination, String Subject, string Content)
        {
            var body = Content;
            var message = new MailMessage();
            message.To.Add(new MailAddress(destination));
            message.CC.Add(new MailAddress(ConfigurationManager.AppSettings.Get("gmailAccountcopy")));
            message.From = new MailAddress(ConfigurationManager.AppSettings.Get("gmailAccountAddress"));
            message.Subject = Subject;
            message.Body = body;
            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = ConfigurationManager.AppSettings.Get("gmailAccountAddress"),
                    Password = ConfigurationManager.AppSettings.Get("gmailAccountPassword")
                };

                smtp.UseDefaultCredentials = false;
                smtp.Credentials = credential;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                try
                {
                    smtp.Send(message);
                }
                catch (Exception)
                {

                }
            }
        }
    }
}