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
    public class AdminController : Controller
    {
        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            if (Session["CurrentUser"] == null)
            {
                RedirectToAction("login", "shared").ExecuteResult(this.ControllerContext);
            }
        }

        public Crud.Models.AppContext db { get; private set; }
        public AdminController()
        {
            db = new Crud.Models.AppContext();
        }

        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.NbUtilisatue = db.Utilisateurs.Where(x => x.Role != Models.Role.Admin).ToList().Count();
            ViewBag.NBFormation = db.Formations.ToList().Count();
            ViewBag.NBEntretien = db.Entreteins.ToList().Count();
            ViewBag.NBTicket = db.Tickets.ToList().Count();
            // view bag 
            // viw data


            return View();
        }
       
        public ActionResult ListeUtilisateurs()
        {
            // Using Model 
            var ListeUtilisateurs = db.Utilisateurs.Where(x=>x.Role!=Models.Role.Admin).ToList();
            return View(ListeUtilisateurs);
        }
        public ActionResult Test()
        {
            return View();
        }
        [HttpPost]
        public JsonResult SaveUtilisateur(Utilisateur Utilisateur)
        {
            Utilisateur.Password = CreateRandomPassword(12);
            db.Utilisateurs.Add(Utilisateur);

            db.SaveChanges();
            // create Password  and send email

            Task.Run(() => SendMail(Utilisateur.Email, "Nouveau compte Utilisateur - Cloud", $"Bonjour {Utilisateur.FullName},{Environment.NewLine}Votre compte courier sur la plateforme Cloud a été crée par l'administrateur.{Environment.NewLine}Nom d'utilisateur: {Utilisateur.Email}{Environment.NewLine}Mot de passe: {Utilisateur.Password}{Environment.NewLine}URL:  {Environment.NewLine}Cordialement,{Environment.NewLine}Équipe Cloud Management"));
            return Json("Sucess", JsonRequestBehavior.AllowGet);
        }
        private static string CreateRandomPassword(int passwordLength)
        {
            string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@$?_-";
            char[] chars = new char[passwordLength];
            Random rd = new Random();

            for (int i = 0; i < passwordLength; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }

            return new string(chars);
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

        public ActionResult ListedesCV()
        {
            var ListedesCV = db.CvFiles.ToList();
            return View(ListedesCV);
           
        }
        
             public ActionResult ListeFormations()
        {
            var ListeFormations = db.Formations.ToList();
            return View(ListeFormations);

           
        }
        
           public ActionResult ListeTICKETS()
        {
            var ListeTickets = db.Tickets.ToList();
            return View(ListeTickets);

        }

        public ActionResult ListeEntretiens()
        {
            var ListeEntretiens = db.Entreteins.ToList();
            return View(ListeEntretiens);
        }
        
                public ActionResult proposeFormations()
        {
           

            return View();
        }
    }
}