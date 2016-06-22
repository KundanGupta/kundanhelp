using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropertyPortal.Controllers
{
    public class PropertyMasterController : Controller
    {
        private propertyportalEntities db = new propertyportalEntities();

        //
        // GET: /PropertyMaster/

        public ActionResult Index()
        {
            return View(db.tblpropertymains.ToList());
        }

        //
        // GET: /PropertyMaster/Details/5

        public ActionResult Details(long id = 0)
        {
            tblpropertymain tblpropertymain = db.tblpropertymains.Find(id);
            if (tblpropertymain == null)
            {
                return HttpNotFound();
            }
            return View(tblpropertymain);
        }

        //
        // GET: /PropertyMaster/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /PropertyMaster/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tblpropertymain tblpropertymain)
        {
            if (ModelState.IsValid)
            {
                db.tblpropertymains.Add(tblpropertymain);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblpropertymain);
        }

        //
        // GET: /PropertyMaster/Edit/5

        public ActionResult Edit(long id = 0)
        {
            tblpropertymain tblpropertymain = db.tblpropertymains.Find(id);
            if (tblpropertymain == null)
            {
                return HttpNotFound();
            }
            return View(tblpropertymain);
        }

        //
        // POST: /PropertyMaster/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tblpropertymain tblpropertymain)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblpropertymain).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblpropertymain);
        }

        //
        // GET: /PropertyMaster/Delete/5

        public ActionResult Delete(long id = 0)
        {
            tblpropertymain tblpropertymain = db.tblpropertymains.Find(id);
            if (tblpropertymain == null)
            {
                return HttpNotFound();
            }
            return View(tblpropertymain);
        }

        //
        // POST: /PropertyMaster/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            tblpropertymain tblpropertymain = db.tblpropertymains.Find(id);
            db.tblpropertymains.Remove(tblpropertymain);
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