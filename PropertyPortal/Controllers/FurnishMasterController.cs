using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropertyPortal.Controllers
{
    public class FurnishMasterController : Controller
    {
        private propertyportalEntities db = new propertyportalEntities();

        //
        // GET: /FurnishMaster/

        public ActionResult Index()
        {
            return View(db.tblfurnishmasters.ToList());
        }

        //
        // GET: /FurnishMaster/Details/5

        public ActionResult Details(long id = 0)
        {
            tblfurnishmaster tblfurnishmaster = db.tblfurnishmasters.Find(id);
            if (tblfurnishmaster == null)
            {
                return HttpNotFound();
            }
            return View(tblfurnishmaster);
        }

        //
        // GET: /FurnishMaster/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /FurnishMaster/Create

        [HttpPost]
        public ActionResult Create(tblfurnishmaster tblfurnishmaster)
        {
            if (ModelState.IsValid)
            {
                db.tblfurnishmasters.Add(tblfurnishmaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblfurnishmaster);
        }

        //
        // GET: /FurnishMaster/Edit/5

        public ActionResult Edit(long id = 0)
        {
            tblfurnishmaster tblfurnishmaster = db.tblfurnishmasters.Find(id);
            if (tblfurnishmaster == null)
            {
                return HttpNotFound();
            }
            return View(tblfurnishmaster);
        }

        //
        // POST: /FurnishMaster/Edit/5

        [HttpPost]
        public ActionResult Edit(tblfurnishmaster tblfurnishmaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblfurnishmaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblfurnishmaster);
        }

        //
        // GET: /FurnishMaster/Delete/5

        public ActionResult Delete(long id = 0)
        {
            tblfurnishmaster tblfurnishmaster = db.tblfurnishmasters.Find(id);
            if (tblfurnishmaster == null)
            {
                return HttpNotFound();
            }
            return View(tblfurnishmaster);
        }

        //
        // POST: /FurnishMaster/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            tblfurnishmaster tblfurnishmaster = db.tblfurnishmasters.Find(id);
            db.tblfurnishmasters.Remove(tblfurnishmaster);
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