using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crud.Controllers
{
    public class SharedController : Controller
    {
        // GET: Shared
        public Crud.Models.AppContext db { get; private set; }

        public SharedController()
        {
            db = new Crud.Models.AppContext();
        }

        [HttpGet]
        public ActionResult login()
        {
            int count = db.Utilisateurs.Count();
            return View();
        }

    }
}