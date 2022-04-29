using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Crud.Models;

namespace Crud.Controllers
{
    public class UserController : Controller
    {
        //chalEntities db = new chalEntities();
        //// GET: User
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //public ActionResult Registration()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Registration(User r)
        //{
        //    db.User.Add(r);
        //    db.SaveChanges();
        //    return View();

        //}
        public ActionResult Login()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult Login(User r)
        //{
        //    var lg = db.User.Where(a => a.Matricule.Equals(r.Matricule) && a.Password.Equals(r.Password)).FirstOrDefault();
        //      if(lg!=null)
        //    {
        //        return RedirectToAction("Index","User");
        //    }
        //      else
        //    {
        //        return RedirectToAction("Login","User");
        //    }



        //}




        //// GET: User/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: User/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: User/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: User/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: User/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: User/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: User/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
