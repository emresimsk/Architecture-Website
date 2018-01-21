using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArcWebPage.Identity;
using ArcWebPage.Models;
using Microsoft.AspNet.Identity.Owin;
using BusinessLayer;
using DAL.DB;

namespace ArcWebPage.Controllers
{
    public class AdminController : Controller
    {
        private readonly BusinessLayer.BusinessLayer _db = new BusinessLayer.BusinessLayer();

        public UserManagerApp UserManagerApp
        {
            get
            {
                var context = HttpContext.GetOwinContext();
                return context.GetUserManager<UserManagerApp>();
            }
        }


        public RoleAppManager RoleAppManager => HttpContext.GetOwinContext().GetUserManager<RoleAppManager>();


        public ActionResult Panel()
        {
            return View();
        }


        public ActionResult AboutMeEdit()
        {
            var aboutList = _db.GetAllAboutMes();
            var about = aboutList.Any() ? aboutList.FirstOrDefault() : new AboutMe();
            return View(about);
        }

        [HttpPost]
        public ActionResult AboutMeEdit(AboutMe about, HttpPostedFileBase picture1, HttpPostedFileBase picture2)
        {
            string filePicturePath = null;
            string filePicturePath1 = null;

            if (picture1 != null)
            {
                var filePictureName = Path.GetFileName(picture1.FileName);
                filePicturePath = Path.Combine(Server.MapPath("~/File"), filePictureName);
                picture1.SaveAs(filePicturePath);
            }

            if (picture2 != null)
            {
                var filePictureName1 = Path.GetFileName(picture2.FileName);
                filePicturePath1 = Path.Combine(Server.MapPath("~/File"), filePictureName1);
                picture1.SaveAs(filePicturePath1);
            }


            if (_db.GetAllAboutMes().Any())
            {
                var aboutMe = _db.GetAllAboutMes().FirstOrDefault();

                aboutMe.AboutComment = about.AboutComment;
                aboutMe.Header = about.Header;
                aboutMe.HeaderSecond = about.HeaderSecond;
                aboutMe.ImagePath = filePicturePath;
                aboutMe.ImagePathSecond = filePicturePath1;

                TempData["AboutMe"] = _db.UpdateAboutMe(aboutMe).ToString().ToLower();

                return RedirectToAction("AboutMeEdit");
            }
            about.ImagePath = filePicturePath;
            about.ImagePathSecond = filePicturePath1;

            TempData["AboutMe"] = _db.AddAboutMe(about).ToString().ToLower();

            return RedirectToAction("AboutMeEdit");
        }


        public ActionResult ContactEdit()
        {
            var contant = _db.GetAllContactPages().Any()
                ? _db.GetAllContactPages().FirstOrDefault()
                : new ContactPage();
            return View(contant);
        }

        [HttpPost]
        public ActionResult ContactEdit(ContactPage contact, HttpPostedFileBase picture1)
        {
            string filePicturePath = null;

            if (picture1 != null)
            {
                var filePictureName = Path.GetFileName(picture1.FileName); // dosya adını alıyor
                filePicturePath =
                    Path.Combine(Server.MapPath("~/File"),
                        filePictureName); // dosya adiyla birlikte nereye kaydecegini ayarlıyor
                picture1.SaveAs(filePicturePath);
            }

            if (_db.GetAllContactPages().Any())
            {
                var contactMe = _db.GetAllContactPages().FirstOrDefault();
                contactMe.Comment = contact.Comment;
                contactMe.Title = contact.Title;
                contactMe.ImagePath = filePicturePath;
                TempData["ContactMe"] = _db.UpdateContactPage(contactMe).ToString().ToLower();
            }
            else
            {
                contact.ImagePath = filePicturePath;
                TempData["ContactMe"] = _db.AddContactPage(contact).ToString().ToLower();
            }

            return RedirectToAction("ContactEdit");
        }


        public ActionResult SocialMediaAdd()
        {
            return View();
        }

        [HttpPost]
        public JsonResult getSocialMedia()
        {
            var social = _db.GetAllSocialMedias().Any() ? _db.GetAllSocialMedias() : new List<SocialMedia>();

            return Json(social);
        }

        [HttpPost]
        public JsonResult modifySocialMedia(string id, string name, string link)
        {
            var result = "false";

            if (string.IsNullOrEmpty(id))
            {
                var media = new SocialMedia
                {
                    SocialMediaLink = link,
                    SocialMediaName = name
                };

                result = _db.AddSocialMedia(media).ToString().ToLower();
            }
            else
            {
                var mediaId = Convert.ToDecimal(id);
                var media = _db.GetSocialMediaById(mediaId);
                media.SocialMediaLink = link;
                media.SocialMediaName = name;

                result = _db.UpdateSocialMedia(media).ToString().ToLower();
            }

            return Json(result);
        }

        [HttpPost]
        public JsonResult deleteSocialMedia(string id)
        {
            var result = "false";
            var mediaId = Convert.ToDecimal(id);
            var media = _db.GetSocialMediaById(mediaId);

            if (media != null)
                result = _db.RemoveSocialMedia(media).ToString().ToLower();

            return Json(result);
        }


        public ActionResult SkillList()
        {
            return View();
        }

        [HttpPost]
        public JsonResult getSkills()
        {
            var skillList = _db.GetAllSkilles().Any() ? _db.GetAllSkilles() : new List<Skills>();
            return Json(skillList);
        }

        [HttpPost]
        public JsonResult modifySkill(string id, string name, string value, string colorCode)
        {
            var result = "false";

            if (string.IsNullOrEmpty(id))
            {
                var skill = new Skills
                {
                    ColorCode = colorCode,
                    Name = name,
                    Value = value
                };

                result = _db.AddSkill(skill).ToString().ToLower();
            }
            else
            {
                var skillId = Convert.ToDecimal(id);

                var skill = _db.GetSkillsById(skillId) != null ? _db.GetSkillsById(skillId) : new Skills();

                skill.ColorCode = colorCode;
                skill.Name = name;
                skill.Value = value;

                result = _db.GetSkillsById(skillId) != null
                    ? _db.UpdateSkill(skill).ToString().ToLower()
                    : _db.AddSkill(skill).ToString().ToLower();
            }

            return Json(result);
        }

        [HttpPost]
        public JsonResult deleteSkill(string id)
        {
            var skillId = Convert.ToDecimal(id);
            var skill = _db.GetSkillsById(skillId);
            var result = _db.RemoveSkill(skill).ToString().ToLower();
            return Json(result);
        }


        public ActionResult EducationList()
        {
            return View();
        }

        [HttpPost]
        public JsonResult getEducation()
        {
            var educationList = _db.GetAllEducations().Any() ? _db.GetAllEducations() : new List<Education>();

            return Json(educationList);
        }

        [HttpPost]
        public JsonResult modifyEducation(string id, string year1, string year2, string title, string comment)
        {
            var result = "false";

            if (string.IsNullOrEmpty(id))
            {
                var education = new Education
                {
                    Comment = comment,
                    Title = title,
                    Year = year1 + " - " + year2
                };
                result = _db.AddEducation(education).ToString().ToLower();
            }
            else
            {
                var educationId = Convert.ToDecimal(id);
                var education = _db.GetEducationById(educationId) != null
                    ? _db.GetEducationById(educationId)
                    : new Education();

                education.Comment = comment;
                education.Title = title;
                education.Year = year1 + " - " + year2;

                result = _db.GetEducationById(educationId) != null
                    ? _db.UpdateEducation(education).ToString().ToLower()
                    : _db.AddEducation(education).ToString().ToLower();
            }

            return Json(result);
        }

        [HttpPost]
        public JsonResult deleteEducation(string id)
        {
            var educationId = Convert.ToDecimal(id);
            var education = _db.GetEducationById(educationId);

            var result = _db.RemoveEducation(education).ToString().ToLower();

            return Json(result);
        }


        public ActionResult Projects()
        {
            return View();
        }

        public JsonResult getProjects()
        {
            var projectList = _db.GetAllProjects().Any() ? _db.GetAllProjects() : new List<Project>();

            return Json(projectList);
        }

        public ActionResult ProjectAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProjectAdd(string projectNameUnique, string title, string comment, string titleSecond,
            string commentSecond, string interior, string industrial, HttpPostedFileBase file)
        {
            var project = new Project();

            if (_db.GetProjectByName(projectNameUnique) != null)
                return View();


            string filePicturePath = null;

            if (file != null)
            {
                var filePictureName = Path.GetFileName(file.FileName); // dosya adını alıyor
                filePicturePath =
                    Path.Combine(Server.MapPath("~/File"),
                        filePictureName); // dosya adiyla birlikte nereye kaydecegini ayarlıyor
                file.SaveAs(filePicturePath);
            }

            var type = interior + " " + industrial;
            project.ProjectNameUnique = projectNameUnique.ToLower().Replace(" ", "-").Replace("ş", "s")
                .Replace("ü", "u").Replace("ı", "i")
                .Replace("ğ", "g").Replace("ü", "u")
                .Replace("ö", "o").Replace("ç", "c");
            project.Title = title;
            project.Comment = comment;
            project.TitleSecond = titleSecond;
            project.CommentSecond = commentSecond;
            project.Type = type;
            project.MainPicturePath = filePicturePath;

            if (_db.AddProject(project))
                return RedirectToAction("ProjectImageAdd", new {id = project.ProjectNameUnique});
            return View();
        }

        public ActionResult ProjectImageAdd(string id)
        {
            var project = _db.GetProjectByName(id) != null ? _db.GetProjectByName(id) : new Project();

            return View(project);
        }

        [HttpPost]
        public ActionResult Upload(IEnumerable<HttpPostedFileBase> file, string id)
        {
            var projectId = Convert.ToDecimal(id);

            var result = false;

            if (_db.GetProjectById(projectId) != null)
                foreach (var f in file)
                {
                    string fileName = null;
                    string uploadPath = null;

                    if (f != null)
                    {
                        fileName = Path.GetFileName(f.FileName);
                        uploadPath = Path.Combine(Server.MapPath("~/ProjectImages"), fileName);
                        f.SaveAs(uploadPath);
                    }

                    var imageFile = new ImageFilePath
                    {
                        ProjectID = projectId,
                        ImagePath = "/ProjectImages/" + fileName
                    };
                    result = _db.AddImageFilePath(imageFile);
                }
            return Json(new {Message = result});
        }

        [HttpPost]
        public ActionResult projectDetail(string id)
        {
            var projectAndImages = new ProjectAndImages();

            if (_db.GetProjectByName(id) != null)
            {
                var project = _db.GetProjectByName(id);

                var images = _db.GetImagesByProjectId(project.Id);

                projectAndImages.Project = project;
                projectAndImages.Images = images;
            }

            return View(projectAndImages);
        }
    }
}