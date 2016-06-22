using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropertyPortal.Controllers
{
    public class PropAllUsersController : Controller
    {
        private propertyportalEntities db = new propertyportalEntities();

        //
        // GET: /PropAllUsers/

        public ActionResult Index()
        {
            return View(db.tblportalusers.ToList());
        }

        //
        // GET: /PropAllUsers/Details/5

        public ActionResult Details(long id = 0)
        {
            tblportaluser tblportaluser = db.tblportalusers.Find(id);
            if (tblportaluser == null)
            {
                return HttpNotFound();
            }
            return View(tblportaluser);
        }

        //
        // GET: /PropAllUsers/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /PropAllUsers/Create

        [HttpPost]
        public ActionResult Create(tblportaluser tblportaluser, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string[] AllowedFileExtensions = new string[] { ".jpg", ".gif", ".png", ".jpeg" };
                    int MaxContentLength = 1024 * 1024 * 3; //3 MB
                    string extension = file.FileName.Substring(file.FileName.LastIndexOf('.')).ToString();
                    if (!AllowedFileExtensions.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.'))))
                    {
                        ModelState.AddModelError("ProfilePic", "Please file of type: " + string.Join(", ", AllowedFileExtensions));
                        return View(tblportaluser);
                    }
                    else if (file.ContentLength > MaxContentLength)
                    {
                        ModelState.AddModelError("ProfilePic", "Your file is too large, maximum allowed size is: " + MaxContentLength + " MB");
                        return View(tblportaluser);
                    }
                    string guid = System.Guid.NewGuid().ToString();
                    var filename = Path.GetFileName(file.FileName);
                    filename = guid + extension;
                    var path = Path.Combine(Server.MapPath("~/images/Userpic"), filename);
                    file.SaveAs(path);
                    tblportaluser.ProfilePic = "~/images/Userpic/" + filename.ToString();
                }
                else
                {
                    tblportaluser.ProfilePic = "~/images/Userpic/User.png";
                }


                db.tblportalusers.Add(tblportaluser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblportaluser);
        }

        //
        // GET: /PropAllUsers/Edit/5

        public ActionResult Edit(long id = 0)
        {
            tblportaluser tblportaluser = db.tblportalusers.Find(id);
            if (tblportaluser == null)
            {
                return HttpNotFound();
            }
            return View(tblportaluser);
        }

        //
        // POST: /PropAllUsers/Edit/5

        [HttpPost]
        public ActionResult Edit(tblportaluser tblportaluser, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {

                if (file != null)
                {
                    string[] AllowedFileExtensions = new string[] { ".jpg", ".gif", ".png", ".jpeg" };
                    int MaxContentLength = 1024 * 1024 * 3; //3 MB
                    string extension = file.FileName.Substring(file.FileName.LastIndexOf('.')).ToString();
                    if (!AllowedFileExtensions.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.'))))
                    {
                        ModelState.AddModelError("ProfilePic", "Please file of type: " + string.Join(", ", AllowedFileExtensions));
                        return View(tblportaluser);
                    }
                    else if (file.ContentLength > MaxContentLength)
                    {
                        ModelState.AddModelError("ProfilePic", "Your file is too large, maximum allowed size is: " + MaxContentLength + " MB");
                        return View(tblportaluser);
                    }
                    string guid = System.Guid.NewGuid().ToString();
                    var filename = Path.GetFileName(file.FileName);
                    filename = guid + extension;
                    var path = Path.Combine(Server.MapPath("~/images/Userpic"), filename);
                    file.SaveAs(path);
                    tblportaluser.ProfilePic = "~/images/Userpic/" + filename.ToString();
                }

                db.Entry(tblportaluser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblportaluser);
        }

        //
        // GET: /PropAllUsers/Delete/5

        public ActionResult Delete(long id = 0)
        {
            tblportaluser tblportaluser = db.tblportalusers.Find(id);
            if (tblportaluser == null)
            {
                return HttpNotFound();
            }
            return View(tblportaluser);
        }

        //
        // POST: /PropAllUsers/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            tblportaluser tblportaluser = db.tblportalusers.Find(id);
            db.tblportalusers.Remove(tblportaluser);
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