using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PropertyPortal.Models;

namespace PropertyPortal.Controllers
{
    public class MasterController : Controller
    {
        private propertyportalEntities db = new propertyportalEntities();
        //
        // GET: /Master/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ParentMenu()
        {
            var values = (from c in db.tblmenus
                          where c.IsParent == "Y"
                          select new MasterMenuClass
                          {
                              Id = c.ID,
                              MenuName = c.MenuName,
                              MenuLink = c.MenuLink,
                              Order = c.MenuOrder,
                              HasChild = c.HasChild
                          }).ToList();

            return PartialView("_MenuMasterP", values);
        }

        public ActionResult ChildMenu(long id = 0)
        {
            var values = (from c in db.tblmenus
                          where c.ParentID == id
                          select new MasterMenuClass
                          {
                              Id = c.ID,
                              MenuName = c.MenuName,
                              MenuLink = c.MenuLink,
                              Order = c.MenuOrder,
                              HasChild = c.HasChild
                          }).ToList();

            return PartialView("_MenuMasterC", values);
        }

    }
}
