using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropertyPortal.Controllers
{
    public class PropertyTypeController : Controller
    {
        private propertyportalEntities db = new propertyportalEntities();

        //
        // GET: /PropertyType/

        public ActionResult Index()
        {
            return View(db.tblpropertytypes.ToList());
        }

        //
        // GET: /PropertyType/Details/5

        public ActionResult Details(long id = 0)
        {
            tblpropertytype tblpropertytype = db.tblpropertytypes.Find(id);
            if (tblpropertytype == null)
            {
                return HttpNotFound();
            }
            return View(tblpropertytype);
        }

        //
        // GET: /PropertyType/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /PropertyType/Create

        [HttpPost]
        public ActionResult Create(tblpropertytype tblpropertytype)
        {
            if (ModelState.IsValid)
            {
                db.tblpropertytypes.Add(tblpropertytype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblpropertytype);
        }

        //
        // GET: /PropertyType/Edit/5

        public ActionResult Edit(long id = 0)
        {
            tblpropertytype tblpropertytype = db.tblpropertytypes.Find(id);
            if (tblpropertytype == null)
            {
                return HttpNotFound();
            }
            return View(tblpropertytype);
        }

        //
        // POST: /PropertyType/Edit/5

        [HttpPost]
        public ActionResult Edit(tblpropertytype tblpropertytype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblpropertytype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblpropertytype);
        }

        //
        // GET: /PropertyType/Delete/5

        public ActionResult Delete(long id = 0)
        {
            tblpropertytype tblpropertytype = db.tblpropertytypes.Find(id);
            if (tblpropertytype == null)
            {
                return HttpNotFound();
            }
            return View(tblpropertytype);
        }

        //
        // POST: /PropertyType/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            tblpropertytype tblpropertytype = db.tblpropertytypes.Find(id);
            db.tblpropertytypes.Remove(tblpropertytype);
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