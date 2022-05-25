using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
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
            var Entretien = db.Entreteins.Where(x => x.Utilisateur.Id == Utilisateur.Id).FirstOrDefault();

            var ListeObjectif = Entretien.Objectifs.Where(x=>x.Status_Obj==Status_Obj.En_attente).ToList();
            if(ListeObjectif.Count()>0)
            {
                ViewBag.AnnerObj = ListeObjectif.FirstOrDefault().Annee;
            }
          var a=  Entretien.Objectifs.Any(x => x.Status_Obj == Status_Obj.En_attente);
            return View(Entretien);
        }
        [HttpPost]
        public JsonResult SavevalideEvaluation(string Commantaire_Employee)
        {
            Utilisateur utilisateur = Session["CurrentUser"] as Utilisateur;
            var Utilisateur = db.Utilisateurs.Find(utilisateur.Id);
            var Entretien = db.Entreteins.Where(x => x.Utilisateur.Id == Utilisateur.Id).FirstOrDefault();
            Entretien.Commantaire_Employee = Commantaire_Employee;
            Entretien.Etat = Etat.Entretein_Cloturé;
            db.SaveChanges();
            return Json("Sucess", JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult SavereserveEvaluation(string Commantaire_Employee)
        {
            Utilisateur utilisateur = Session["CurrentUser"] as Utilisateur;
            var Utilisateur = db.Utilisateurs.Find(utilisateur.Id);
            var Entretien = db.Entreteins.Where(x => x.Utilisateur.Id == Utilisateur.Id).FirstOrDefault();
            foreach(var obj in Entretien.Objectifs)
            {
                obj.Status_Obj = Status_Obj.Reserve;
                db.SaveChanges();
            }
            Entretien.Commantaire_Employee = Commantaire_Employee;
            Entretien.Etat = Etat.Evaluation;
            db.SaveChanges();
            return Json("Sucess", JsonRequestBehavior.AllowGet);
        }
        
              [HttpPost]
        public JsonResult SaveObjectifSatut(int status, string commentaire, int anner)
        {
            Utilisateur utilisateur = Session["CurrentUser"] as Utilisateur;
            var Utilisateur = db.Utilisateurs.Find(utilisateur.Id);
            var Entretien = db.Entreteins.Where(x => x.Utilisateur.Id == Utilisateur.Id).FirstOrDefault();

            var ListeObjectif = Entretien.Objectifs.Where(x=>x.Annee== anner).ToList();
            var Status_Objectif = new Status_Obj();
            if (status == 1)
            { Status_Objectif = Status_Obj.Valide;
                var ManagerCode = Utilisateur.Manager;
              var Manager=  db.Utilisateurs.Where(x => x.Matricule.Equals(ManagerCode)).FirstOrDefault();
                if(Manager!=null)
                Task.Run(() => SendMail(Manager.Email, "Compte -Challenge", $"Bonjour {Manager.FullName},{Environment.NewLine}Vos Collaborateurs {utilisateur.FullName}  à été valider ses objectifs , Merci de consulter votre platforme.{Environment.NewLine}Cordialement,{Environment.NewLine}Équipe Challenge"));
            }
            if (status == 2)
            { Status_Objectif = Status_Obj.Reserve;
                var ManagerCode = Utilisateur.Manager;
                var Manager = db.Utilisateurs.Where(x => x.Matricule.Equals(ManagerCode)).FirstOrDefault();
                if (Manager != null)
                    Task.Run(() => SendMail(Manager.Email, "Compte -Challenge", $"Bonjour {Manager.FullName},{Environment.NewLine}Vos Collaborateurs  {utilisateur.FullName} à été reserver ses objectifs , Merci de consulter votre platforme.{Environment.NewLine}Cordialement,{Environment.NewLine}Équipe Challenge"));
            }

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
