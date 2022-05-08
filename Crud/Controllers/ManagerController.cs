using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crud.Controllers
{
    public class ManagerController : Controller
    {
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
      
                 public ActionResult ListeCollaborateurs()
        {
            return View();
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