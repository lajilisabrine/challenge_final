﻿using System;
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
    }
}