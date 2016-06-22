using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropertyPortal.Controllers
{
    public class PropertyCategoryController : Controller
    {
        private propertyportalEntities db = new propertyportalEntities();

        //
        // GET: /PropertyCategory/

        public ActionResult Index()
        {
            return View(db.tblpropertycategories.ToList());
        }

        //
        // GET: /PropertyCategory/Details/5

        public ActionResult Details(long id = 0)
        {
            tblpropertycategory tblpropertycategory = db.tblpropertycategories.Find(id);
            if (tblpropertycategory == null)
            {
                return HttpNotFound();
            }
            return View(tblpropertycategory);
        }

        //
        // GET: /PropertyCategory/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /PropertyCategory/Create

        [HttpPost]
        public ActionResult Create(tblpropertycategory tblpropertycategory)
        {
            if (ModelState.IsValid)
            {
                db.tblpropertycategories.Add(tblpropertycategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblpropertycategory);
        }

        //
        // GET: /PropertyCategory/Edit/5

        public ActionResult Edit(long id = 0)
        {
            tblpropertycategory tblpropertycategory = db.tblpropertycategories.Find(id);
            if (tblpropertycategory == null)
            {
                return HttpNotFound();
            }
            return View(tblpropertycategory);
        }

        //
        // POST: /PropertyCategory/Edit/5

        [HttpPost]
        public ActionResult Edit(tblpropertycategory tblpropertycategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblpropertycategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblpropertycategory);
        }

        //
        // GET: /PropertyCategory/Delete/5

        public ActionResult Delete(long id = 0)
        {
            tblpropertycategory tblpropertycategory = db.tblpropertycategories.Find(id);
            if (tblpropertycategory == null)
            {
                return HttpNotFound();
            }
            return View(tblpropertycategory);
        }

        //
        // POST: /PropertyCategory/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            tblpropertycategory tblpropertycategory = db.tblpropertycategories.Find(id);
            db.tblpropertycategories.Remove(tblpropertycategory);
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