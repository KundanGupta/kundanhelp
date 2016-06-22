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
    public class PropertyAgentsController : Controller
    {
        private propertyportalEntities db = new propertyportalEntities();

        //
        // GET: /PropertyAgents/

        public ActionResult Index()
        {
            return View(db.tblpropagents.ToList());
        }

        //
        // GET: /PropertyAgents/Details/5

        public ActionResult Details(long id = 0)
        {
            tblpropagent tblpropagent = db.tblpropagents.Find(id);
            if (tblpropagent == null)
            {
                return HttpNotFound();
            }
            return View(tblpropagent);
        }

        //
        // GET: /PropertyAgents/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /PropertyAgents/Create

        [HttpPost]
        public ActionResult Create(tblpropagent tblpropagent, HttpPostedFileBase file)
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
                        return View(tblpropagent);
                    }
                    else if (file.ContentLength > MaxContentLength)
                    {
                        ModelState.AddModelError("ProfilePic", "Your file is too large, maximum allowed size is: " + MaxContentLength + " MB");
                        return View(tblpropagent);
                    }
                    string guid = System.Guid.NewGuid().ToString();
                    var filename = Path.GetFileName(file.FileName);
                    filename = guid + extension;
                    var path = Path.Combine(Server.MapPath("~/images/Agentpic"), filename);
                    file.SaveAs(path);
                    tblpropagent.ProfilePic = "~/images/Agentpic/" + filename.ToString();
                }
                else
                {
                    tblpropagent.ProfilePic = "~/images/Agentpic/User.png";
                }


                db.tblpropagents.Add(tblpropagent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblpropagent);
        }

        //
        // GET: /PropertyAgents/Edit/5

        public ActionResult Edit(long id = 0)
        {
            tblpropagent tblpropagent = db.tblpropagents.Find(id);
            if (tblpropagent == null)
            {
                return HttpNotFound();
            }
            return View(tblpropagent);
        }

        //
        // POST: /PropertyAgents/Edit/5

        [HttpPost]
        public ActionResult Edit(tblpropagent tblpropagent, HttpPostedFileBase file)
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
                        return View(tblpropagent);
                    }
                    else if (file.ContentLength > MaxContentLength)
                    {
                        ModelState.AddModelError("ProfilePic", "Your file is too large, maximum allowed size is: " + MaxContentLength + " MB");
                        return View(tblpropagent);
                    }
                    string guid = System.Guid.NewGuid().ToString();
                    var filename = Path.GetFileName(file.FileName);
                    filename = guid + extension;
                    var path = Path.Combine(Server.MapPath("~/images/Agentpic"), filename);
                    file.SaveAs(path);
                    tblpropagent.ProfilePic = "~/images/Agentpic/" + filename.ToString();
                }


                db.Entry(tblpropagent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblpropagent);
        }

        //
        // GET: /PropertyAgents/Delete/5

        public ActionResult Delete(long id = 0)
        {
            tblpropagent tblpropagent = db.tblpropagents.Find(id);
            if (tblpropagent == null)
            {
                return HttpNotFound();
            }
            return View(tblpropagent);
        }

        //
        // POST: /PropertyAgents/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            tblpropagent tblpropagent = db.tblpropagents.Find(id);
            db.tblpropagents.Remove(tblpropagent);
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