using PropertyPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PropertyPortal.Controllers
{
    public class AdminController : Controller
    {
        private propertyportalEntities db = new propertyportalEntities();
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            if (System.Web.HttpContext.Current.Items.Count != 0)
            {
                try
                {
                    if (System.Web.HttpContext.Current.Items["Role"].ToString() == "A")
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                catch
                {
                    return View();
                }
            }

            return View();
        }

        [HttpPost]
        public ActionResult Index(tbladminlogin user)
        {

            var validation = (from c in db.tbladminlogins
                              where c.UserName == user.UserName && c.Password == user.Password
                              select new
                              {
                                  UserID = c.ID,
                              }).SingleOrDefault(); ;

            if (validation == null)
            {
                ViewBag.Message = "Invalid Username or Password.";
                return View(user);
            }

            CustomPrincipalSerializeModel serializeModel = new CustomPrincipalSerializeModel();
            serializeModel.UserId = Convert.ToInt32(validation.UserID);
            serializeModel.FirstName = validation.UserID.ToString();
            serializeModel.roles = "A";

            string userData = Newtonsoft.Json.JsonConvert.SerializeObject(serializeModel);

            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, "userName", DateTime.Now, DateTime.Now.AddMinutes(120), // value of time out property
                                                                            false, // Value of IsPersistent property
                                                                            userData);
            string encTicket = FormsAuthentication.Encrypt(authTicket);
            HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
            Response.Cookies.Add(faCookie);
            return RedirectToAction("Index", "FurnishMaster");
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Admin");
        }

    }
}
