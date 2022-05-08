using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crud.Controllers
{
    public class RHController : Controller
    {
        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            if (Session["CurrentUser"] == null)
            {
                RedirectToAction("login", "shared").ExecuteResult(this.ControllerContext);
            }
        }
        public Crud.Models.AppContext db { get; private set; }
        public RHController()
        {
            db = new Crud.Models.AppContext();
        }
        // GET: RH
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListeUtilisateurs()
        {
            return View(db.Utilisateurs.ToList());
        }
        public ActionResult Test()
        {
            return View();
        }

        public ActionResult RechercheUtilisateurs()
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