using System;
using System.Web;
using System.Web.Mvc;
using ArcWebPage.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace ArcWebPage.Controllers
{
    public class HomeController : Controller
    {
        public UserManagerApp UserManagerApp
        {
            get
            {
                var context = HttpContext.GetOwinContext();
                return context.GetUserManager<UserManagerApp>();
            }
        }

        public RoleAppManager RoleAppManager => HttpContext.GetOwinContext().GetUserManager<RoleAppManager>();


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
                var currentUser = UserManagerApp.Find(username, password);

                if (currentUser != null)
                {
                    var identy =
                        UserManagerApp.CreateIdentity(currentUser, DefaultAuthenticationTypes.ApplicationCookie);

                    HttpContext.GetOwinContext().Authentication.SignOut();
                    HttpContext.GetOwinContext().Authentication.SignIn(new AuthenticationProperties
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