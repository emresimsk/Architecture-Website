using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using ArcWebPage.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace ArcWebPage.Controllers
{
    public class HomeController : Controller
    {
        public UserManagerApp UserManagerApp
        {

            get
            {
                IOwinContext context = HttpContext.GetOwinContext();
                return context.GetUserManager<UserManagerApp>();
            }
        }

        public RoleAppManager RoleAppManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<RoleAppManager>();
            }
        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Project()
        {
            return View();
        }

        public ActionResult Portfolio()
        {
            return View();
        }

        public ActionResult Portfolioo()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Admin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Admin(string username, string password)
        {

            if (ModelState.IsValid)
            {
                UserApp currentUser = UserManagerApp.Find(username, password);

                if (currentUser != null)
                {
                    ClaimsIdentity identy = UserManagerApp.CreateIdentity(currentUser, DefaultAuthenticationTypes.ApplicationCookie);

                    HttpContext.GetOwinContext().Authentication.SignOut();
                    HttpContext.GetOwinContext().Authentication.SignIn(new AuthenticationProperties()
                    {
                        IsPersistent = false,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)

                    }, identy);


                    return RedirectToAction("Panel", "Admin");
                }
            }

            ModelState.AddModelError("", "Invalid username or password.");
            return View();
        }
    }
}