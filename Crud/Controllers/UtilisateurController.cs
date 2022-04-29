using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Crud.Models;

namespace Crud.Controllers
{
    public class UtilisateurController : Controller
    {
        //chalEntities db = new chalEntities();
        //// GET: Utilisateur
        //public ActionResult Index()
        //{
        //    return View();
        //}
        //public ActionResult AjoutUtilisateur() //enregistrement 
        //{
        //    try
        //    {
        //        ViewBag.listeUtilisateur = db.User.ToList();
        //        return View();
        //    }
        //    catch (Exception)
        //    {
        //        return HttpNotFound();

        //    }
        //}
        //[HttpPost]

        //public ActionResult AjoutUtilisateur(User user)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {

        //            db.User.Add(user);

        //            db.SaveChanges();

        //        }
        //        return RedirectToAction("AjoutUtilisateur");
        //    }
        //    catch (Exception)
        //    {
        //        return HttpNotFound();

        //    }
        //}
        //public ActionResult SupprimerUtilisateur(int id)
        //{
        //    try
        //    {
        //        User user = db.User.Find(id);
        //        if (user != null)
        //        {
        //            db.User.Remove(user); // supression utilisateur
        //            db.SaveChanges();

        //        }
        //        return RedirectToAction("AjoutUtilisateur");
        //    }
        //    catch (Exception)
        //    {
        //        return HttpNotFound();

        //    }

        //}

        //public ActionResult ModifierUtilisateur(int id)
        //{
        //    try
        //    {
        //        ViewBag.listeUtilisateur = db.User.ToList();

        //        User user = db.User.Find(id);
        //        if (user != null)
        //        {

        //            return View("AjoutUtilisateur", user);

        //        }
        //        return RedirectToAction("AjoutUtilisateur");
        //    }
        //    catch (Exception)
        //    {
        //        return HttpNotFound();

        //    }

        //}
        //[HttpPost]
        //public ActionResult ModifierUtilisateur(User user)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            db.Entry(user).State = EntityState.Modified;//modifier user
        //            db.SaveChanges();
        //        }


        //        return RedirectToAction("AjoutUtilisateur");
        //    }
        //    catch (Exception)
        //    {
        //        return HttpNotFound();


        //    }
        //}
    }
}