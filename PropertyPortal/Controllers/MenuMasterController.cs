using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropertyPortal.Controllers
{
    public class MenuMasterController : Controller
    {
        private propertyportalEntities db = new propertyportalEntities();

        //
        // GET: /MenuMaster/

        public ActionResult Index()
        {
            return View(db.tblmenus.ToList());
        }

        //
        // GET: /MenuMaster/Details/5

        public ActionResult Details(long id = 0)
        {
            tblmenu tblmenu = db.tblmenus.Find(id);
            if (tblmenu == null)
            {
                return HttpNotFound();
            }
            return View(tblmenu);
        }

        //
        // GET: /MenuMaster/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /MenuMaster/Create

        [HttpPost]
        public ActionResult Create(tblmenu tblmenu)
        {
            if (ModelState.IsValid)
            {
                db.tblmenus.Add(tblmenu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblmenu);
        }

        //
        // GET: /MenuMaster/Edit/5

        public ActionResult Edit(long id = 0)
        {
            tblmenu tblmenu = db.tblmenus.Find(id);
            if (tblmenu == null)
            {
                return HttpNotFound();
            }
            return View(tblmenu);
        }

        //
        // POST: /MenuMaster/Edit/5

        [HttpPost]
        public ActionResult Edit(tblmenu tblmenu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblmenu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblmenu);
        }

        //
        // GET: /MenuMaster/Delete/5

        public ActionResult Delete(long id = 0)
        {
            tblmenu tblmenu = db.tblmenus.Find(id);
            if (tblmenu == null)
            {
                return HttpNotFound();
            }
            return View(tblmenu);
        }

        //
        // POST: /MenuMaster/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            tblmenu tblmenu = db.tblmenus.Find(id);
            db.tblmenus.Remove(tblmenu);
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