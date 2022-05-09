using System;
using System.Collections.Generic;
using System.Linq;
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