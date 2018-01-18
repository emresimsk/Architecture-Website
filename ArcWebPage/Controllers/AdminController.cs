using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArcWebPage.Identity;
using DAL;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using BusinessLayer = BusinessLayer.BusinessLayer;

namespace ArcWebPage.Controllers
{
    public class AdminController : Controller
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


        public global::BusinessLayer.BusinessLayer _db = new global::BusinessLayer.BusinessLayer();


        public ActionResult Panel()
        {
            return View();
        } 


        public ActionResult AboutMeEdit()
        {
            AboutMe about = (_db.GetAllAboutMes().Any()) ? _db.GetAllAboutMes().FirstOrDefault() : new AboutMe();
            return View(about);
        } 

        [HttpPost]
        public ActionResult AboutMeEdit(AboutMe about, HttpPostedFileBase picture1, HttpPostedFileBase picture2)
        {
            string filePicturePath = null;
            string filePicturePath1 = null;

            if (picture1 != null)
            {
                string filePictureName = Path.GetFileName(picture1.FileName); 
                filePicturePath = Path.Combine(Server.MapPath("~/File"), filePictureName); 
                picture1.SaveAs(filePicturePath);
            }

            if (picture2 != null)
            {
                string filePictureName1 = Path.GetFileName(picture1.FileName);  
                filePicturePath1 = Path.Combine(Server.MapPath("~/File"), filePictureName1);
                picture1.SaveAs(filePicturePath1);
            }


            if (_db.GetAllAboutMes().Any())
            {
                AboutMe aboutMe = _db.GetAllAboutMes().FirstOrDefault();

                aboutMe.AboutComment = about.AboutComment;
                aboutMe.Header = about.Header;
                aboutMe.HeaderSecond = about.HeaderSecond;
                aboutMe.ImagePath = filePicturePath;
                aboutMe.ImagePathSecond = filePicturePath1;

                TempData["AboutMe"] = (_db.UpdateAboutMe(aboutMe)) ? "true" : "false";

                return RedirectToAction("AboutMeEdit");
            }
            else
            {
                about.ImagePath = filePicturePath;
                about.ImagePathSecond = filePicturePath1;

                TempData["AboutMe"] = (_db.AddAboutMe(about)) ? "true" : "false";
 
                return RedirectToAction("AboutMeEdit");
            }
        }


        public ActionResult ContactEdit()
        {
            ContactPage contant = (_db.GetAllContactPages().Any()) ? _db.GetAllContactPages().FirstOrDefault() : new ContactPage();
            return View(contant);
        }

        [HttpPost]
        public ActionResult ContactEdit(ContactPage contact, HttpPostedFileBase picture1)
        {
            string filePicturePath = null;

            if (picture1 != null)
            {
                string filePictureName = Path.GetFileName(picture1.FileName);  // dosya adını alıyor
                filePicturePath = Path.Combine(Server.MapPath("~/File"), filePictureName); // dosya adiyla birlikte nereye kaydecegini ayarlıyor
                picture1.SaveAs(filePicturePath);
            }

            if (_db.GetAllContactPages().Any())
            {
                ContactPage contactMe = _db.GetAllContactPages().FirstOrDefault();
                contactMe.Comment = contact.Comment;
                contactMe.Title = contact.Title;
                contactMe.ImagePath = filePicturePath;
                TempData["ContactMe"] = (_db.UpdateContactPage(contactMe)) ? "true" : "false";
            }
            else
            {
                contact.ImagePath = filePicturePath;
                TempData["ContactMe"] = (_db.AddContactPage(contact)) ? "true" : "false";
            }

            return RedirectToAction("ContactEdit");
        }
    }
}