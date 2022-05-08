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
            return View();
        }
        
             public ActionResult ListeFormations()
        {
            return View();
        }
        
    

        
           public ActionResult ListeTICKETS()
        {
            return View();
        }
        
            public ActionResult ListeEntretiens()
        {
            return View();
        }
    }
}