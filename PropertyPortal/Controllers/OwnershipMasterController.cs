using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropertyPortal.Controllers
{
    public class OwnershipMasterController : Controller
    {
        private propertyportalEntities db = new propertyportalEntities();

        //
        // GET: /OwnershipMaster/

        public ActionResult Index()
        {
            return View(db.tblownershiptypemasters.ToList());
        }

        //
        // GET: /OwnershipMaster/Details/5

        public ActionResult Details(long id = 0)
        {
            tblownershiptypemaster tblownershiptypemaster = db.tblownershiptypemasters.Find(id);
            if (tblownershiptypemaster == null)
            {
                return HttpNotFound();
            }
            return View(tblownershiptypemaster);
        }

        //
        // GET: /OwnershipMaster/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /OwnershipMaster/Create

        [HttpPost]
        public ActionResult Create(tblownershiptypemaster tblownershiptypemaster)
        {
            if (ModelState.IsValid)
            {
                db.tblownershiptypemasters.Add(tblownershiptypemaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblownershiptypemaster);
        }

        //
        // GET: /OwnershipMaster/Edit/5

        public ActionResult Edit(long id = 0)
        {
            tblownershiptypemaster tblownershiptypemaster = db.tblownershiptypemasters.Find(id);
            if (tblownershiptypemaster == null)
            {
                return HttpNotFound();
            }
            return View(tblownershiptypemaster);
        }

        //
        // POST: /OwnershipMaster/Edit/5

        [HttpPost]
        public ActionResult Edit(tblownershiptypemaster tblownershiptypemaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblownershiptypemaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblownershiptypemaster);
        }

        //
        // GET: /OwnershipMaster/Delete/5

        public ActionResult Delete(long id = 0)
        {
            tblownershiptypemaster tblownershiptypemaster = db.tblownershiptypemasters.Find(id);
            if (tblownershiptypemaster == null)
            {
                return HttpNotFound();
            }
            return View(tblownershiptypemaster);
        }

        //
        // POST: /OwnershipMaster/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            tblownershiptypemaster tblownershiptypemaster = db.tblownershiptypemasters.Find(id);
            db.tblownershiptypemasters.Remove(tblownershiptypemaster);
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