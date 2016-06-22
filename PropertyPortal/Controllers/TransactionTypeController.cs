using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropertyPortal.Controllers
{
    public class TransactionTypeController : Controller
    {
        private propertyportalEntities db = new propertyportalEntities();

        //
        // GET: /TransactionType/

        public ActionResult Index()
        {
            return View(db.tbltrantypemasters.ToList());
        }

        //
        // GET: /TransactionType/Details/5

        public ActionResult Details(long id = 0)
        {
            tbltrantypemaster tbltrantypemaster = db.tbltrantypemasters.Find(id);
            if (tbltrantypemaster == null)
            {
                return HttpNotFound();
            }
            return View(tbltrantypemaster);
        }

        //
        // GET: /TransactionType/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /TransactionType/Create

        [HttpPost]
        public ActionResult Create(tbltrantypemaster tbltrantypemaster)
        {
            if (ModelState.IsValid)
            {
                db.tbltrantypemasters.Add(tbltrantypemaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbltrantypemaster);
        }

        //
        // GET: /TransactionType/Edit/5

        public ActionResult Edit(long id = 0)
        {
            tbltrantypemaster tbltrantypemaster = db.tbltrantypemasters.Find(id);
            if (tbltrantypemaster == null)
            {
                return HttpNotFound();
            }
            return View(tbltrantypemaster);
        }

        //
        // POST: /TransactionType/Edit/5

        [HttpPost]
        public ActionResult Edit(tbltrantypemaster tbltrantypemaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbltrantypemaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbltrantypemaster);
        }

        //
        // GET: /TransactionType/Delete/5

        public ActionResult Delete(long id = 0)
        {
            tbltrantypemaster tbltrantypemaster = db.tbltrantypemasters.Find(id);
            if (tbltrantypemaster == null)
            {
                return HttpNotFound();
            }
            return View(tbltrantypemaster);
        }

        //
        // POST: /TransactionType/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            tbltrantypemaster tbltrantypemaster = db.tbltrantypemasters.Find(id);
            db.tbltrantypemasters.Remove(tbltrantypemaster);
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