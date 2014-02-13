﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jan_die_alles_kan.Models;

namespace Jan_die_alles_kan.Controllers
{
    public class defaultcontrollerpages : Controller
    {
        private PagesContext db = new PagesContext();

        //
        // GET: /defaultcontrollerpages/

        public ActionResult Index()
        {
            return View(db.Pages.ToList());
        }

        //
        // GET: /defaultcontrollerpages/Details/5

        public ActionResult Details(int id = 0)
        {
            PagesModels pagesmodels = db.Pages.Find(id);
            if (pagesmodels == null)
            {
                return HttpNotFound();
            }
            return View(pagesmodels);
        }

        //
        // GET: /defaultcontrollerpages/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /defaultcontrollerpages/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PagesModels pagesmodels)
        {
            if (ModelState.IsValid)
            {
                db.Pages.Add(pagesmodels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pagesmodels);
        }

        //
        // GET: /defaultcontrollerpages/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PagesModels pagesmodels = db.Pages.Find(id);
            if (pagesmodels == null)
            {
                return HttpNotFound();
            }
            return View(pagesmodels);
        }

        //
        // POST: /defaultcontrollerpages/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PagesModels pagesmodels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pagesmodels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pagesmodels);
        }

        //
        // GET: /defaultcontrollerpages/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PagesModels pagesmodels = db.Pages.Find(id);
            if (pagesmodels == null)
            {
                return HttpNotFound();
            }
            return View(pagesmodels);
        }

        //
        // POST: /defaultcontrollerpages/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PagesModels pagesmodels = db.Pages.Find(id);
            db.Pages.Remove(pagesmodels);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}