using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Crud.Models;

namespace Crud.Controllers
{
    public class LoginController : Controller
    {
        chalEntities db = new chalEntities();        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
               
                {
                    var obj = db.User.Where(a => a.Matricule.Equals(user.Matricule) && a.Password.Equals(user.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.UserID.ToString();
                        Session["Matricule"] = obj.Matricule.ToString();
                        return RedirectToAction("UserDashBoard");
                    }
                }
            }
            return View(user);
        }

        public ActionResult UserDashBoard()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}  
    