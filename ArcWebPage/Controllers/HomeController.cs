using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArcWebPage.Identity;
using ArcWebPage.Models;
using DAL.DB;
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

        private readonly BusinessLayer.BusinessLayer _db = new BusinessLayer.BusinessLayer();

        public ActionResult Index()
        {
            IEnumerable<ImageFilePath> images = _db.GetAllImageFilePaths().Take(5);
            return View(images);
        }

        public ActionResult Project()
        {
           return View(_db.GetAllProjects());
        }

        public ActionResult Detail(string id)
        {
            ProjectAndImages p = new ProjectAndImages();

            p.Project = _db.GetProjectByName(id);
            p.Images = (p.Project != null) ? _db.GetImagesByProjectId(p.Project.Id) : null;

            return View(p);
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
            AboutModel model = new AboutModel();

            model.About = _db.GetAllAboutMes().FirstOrDefault();
            model.Skills = _db.GetAllSkilles().OrderByDescending(x => x.Value);
            model.Education = _db.GetAllEducations();
            return View(model);
        }

        public ActionResult Contact()
        {
            ContactModel model = new ContactModel();

            model.Contact = _db.GetAllContactPages().FirstOrDefault();
            model.Sociales = _db.GetAllSocialMedias();

            return View(model);
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

        [HttpPost]
        public JsonResult MailSave(string sendFrom , string Name , string Message)
        {
            var requestUserIp = Request.UserHostAddress;
            DateTime dateNow = DateTime.Now;
            if (_db.GetAllBlockIps().Any(x=>x.BlockIp1==requestUserIp))
            {
                return Json("Sending blocked");
            }

            if (_db.GetIpLast5Minute(requestUserIp, dateNow))
            {
                Mails mail = new Mails()
                {
                    Message =  Message,
                    SendDate =  dateNow,
                    SendFromEmailAdress =  sendFrom,
                    SendFromIp = requestUserIp,
                    SendFromName =  Name
                };

                string result = (_db.AddMail(mail)) ? "Mail was sent." : "Mail could not be sent.";
                return Json(result);
            }
            else
            {
                return Json("Wait 5 minutes to send the mail again.Please!");
            }
        }

    }
}