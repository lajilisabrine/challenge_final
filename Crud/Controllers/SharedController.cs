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
          
            return View();
        }
        [HttpPost]
        public JsonResult login(string Email, string pass)
        {

            var user = db.Utilisateurs.SingleOrDefault(a => a.Email.Equals(Email.Trim()));
            if (user != null)
            {
                if (user.Password.Equals(pass.Trim()))
                {
                    Session["CurrentUser"] = user;
                    if (user.Role == Crud.Models.Role.Admin)
                    {
                        return Json("Admin", JsonRequestBehavior.AllowGet);
                    }
                    if (user.Role == Crud.Models.Role.User)
                    {
                        return Json("User", JsonRequestBehavior.AllowGet);
                    }
                    if (user.Role == Crud.Models.Role.Manager)
                    {
                        return Json("Manager", JsonRequestBehavior.AllowGet);
                    }
                    if (user.Role == Crud.Models.Role.RH)
                    {
                        return Json("RH", JsonRequestBehavior.AllowGet);
                    }
                    return Json("Utilisateur", JsonRequestBehavior.AllowGet);


                }

                else
                {
                    ViewBag.error1 = "Mot De Passe Incorrecte";
                    return Json("Mot De Passe Incorrecte", JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                ViewBag.error = "Utilisateur Invalide";
                return Json("Utilisateur Invalide", JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("login");
        }

    }
}