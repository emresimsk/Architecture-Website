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
using DAL;
using DAL.DB;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

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

        [Authorize]
        public ActionResult Panel()
        {
            return View();
        }

        [Authorize]
        public ActionResult AboutMeEdit()
        {
            var aboutList = _db.GetAllAboutMes();
            var about = aboutList.Any() ? aboutList.FirstOrDefault() : new AboutMe();
            return View(about);
        }

        [Authorize]
        [HttpPost]
        public ActionResult AboutMeEdit(AboutMe about, HttpPostedFileBase picture1, HttpPostedFileBase picture2)
        {

            string filePictureName1 = null;
            string filePictureName2 = null;

            if (picture1 != null)
            {
                filePictureName1 = Path.GetFileName(picture1.FileName);
                string filePicturePath1 = Path.Combine(Server.MapPath("~/File/about"), filePictureName1);
                picture1.SaveAs(filePicturePath1);
            }

            if (picture2 != null)
            {
                filePictureName2 = Path.GetFileName(picture2.FileName);
                string filePicturePath2 = Path.Combine(Server.MapPath("~/File/about"), filePictureName2);
                picture2.SaveAs(filePicturePath2);
            }


            if (_db.GetAllAboutMes().Any())
            {
                AboutMe aboutMe = _db.GetAllAboutMes().FirstOrDefault();

                deleteImage(aboutMe.ImagePath);
                deleteImage(aboutMe.ImagePathSecond);

                aboutMe.AboutComment = about.AboutComment;
                aboutMe.Header = about.Header;
                aboutMe.HeaderSecond = about.HeaderSecond;
                aboutMe.ImagePath = "/File/about/" + filePictureName1;
                aboutMe.ImagePathSecond = "/File/about/" + filePictureName2;
                TempData["AboutMe"] = _db.UpdateAboutMe(aboutMe).ToString().ToLower();

            }
            else
            {
                about.ImagePath = "/File/about/" + filePictureName1;
                about.ImagePathSecond = "/File/about/" + filePictureName2;
          
                TempData["AboutMe"] = _db.AddAboutMe(about).ToString().ToLower();
            }

            return RedirectToAction("AboutMeEdit");
        }

        [Authorize]
        public ActionResult ContactEdit()
        {
            var contantList = _db.GetAllContactPages();
            var contant = contantList.Any() ? contantList.FirstOrDefault() : new ContactPage();
            return View(contant);
        }

        [Authorize]
        [HttpPost]
        public ActionResult ContactEdit(ContactPage contact, HttpPostedFileBase picture1)
        {
            string filePictureName = null;

            if (picture1 != null)
            {
                filePictureName = Path.GetFileName(picture1.FileName); // dosya adını alıyor
                string filePicturePath = Path.Combine(Server.MapPath("~/File/contact"),filePictureName); // dosya adiyla birlikte nereye kaydecegini ayarlıyor
                picture1.SaveAs(filePicturePath);
            }

            if (_db.GetAllContactPages().Any())
            {
                var contactMe = _db.GetAllContactPages().FirstOrDefault();

                deleteImage(contactMe.ImagePath);

                contactMe.Comment = contact.Comment;
                contactMe.Title = contact.Title;
                contactMe.ImagePath = "/File/contact/"+filePictureName;
                TempData["ContactMe"] = _db.UpdateContactPage(contactMe).ToString().ToLower();
            }
            else
            {
                contact.ImagePath = "/File/contact/" + filePictureName; ;
                TempData["ContactMe"] = _db.AddContactPage(contact).ToString().ToLower();
            }

            return RedirectToAction("ContactEdit");
        }

        [Authorize]
        public ActionResult SocialMediaAdd()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public JsonResult getSocialMedia()
        {
            var social = _db.GetAllSocialMedias().Any() ? _db.GetAllSocialMedias() : new List<SocialMedia>();

            return Json(social);
        }

        [Authorize]
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

        [Authorize]
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

        [Authorize]
        public ActionResult SkillList()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public JsonResult getSkills()
        {
            var skillList = _db.GetAllSkilles().Any() ? _db.GetAllSkilles() : new List<Skills>();
            return Json(skillList);
        }

        [Authorize]
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

        [Authorize]
        [HttpPost]
        public JsonResult deleteSkill(string id)
        {
            var skillId = Convert.ToDecimal(id);
            var skill = _db.GetSkillsById(skillId);
            var result = _db.RemoveSkill(skill).ToString().ToLower();
            return Json(result);
        }

        [Authorize]
        public ActionResult EducationList()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public JsonResult getEducation()
        {
            var educationList = _db.GetAllEducations().Any() ? _db.GetAllEducations() : new List<Education>();

            return Json(educationList);
        }

        [Authorize]
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

        [Authorize]
        [HttpPost]
        public JsonResult deleteEducation(string id)
        {
            var educationId = Convert.ToDecimal(id);
            var education = _db.GetEducationById(educationId);

            var result = _db.RemoveEducation(education).ToString().ToLower();

            return Json(result);
        }

        [Authorize]
        public ActionResult Projects()
        {
            return View();
        }

        [Authorize]
        public JsonResult getProjects()
        {
            var projectList = _db.GetAllProjects().Any() ? _db.GetAllProjects() : new List<Project>();

            return Json(projectList);
        }

        [Authorize]
        public ActionResult ProjectAdd()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult ProjectAdd(string projectNameUnique, string title, string comment, string titleSecond,
                                       string commentSecond, string interior, string industrial, HttpPostedFileBase file)
        {
            var project = new Project();

            if (_db.GetProjectByName(projectNameUnique) != null)
                return View();


            var type = interior + " " + industrial;
            project.ProjectNameUnique = projectNameUnique.ToLower().Replace(" ", "-").Replace("ş", "s")
                                                                   .Replace("ü", "u").Replace("ı", "i")
                                                                   .Replace("ğ", "g").Replace("ü", "u")
                                                                   .Replace("ö", "o").Replace("ç", "c");


            string filePictureName = null;

            if (file != null)
            {
                filePictureName = Path.GetFileName(file.FileName);

                bool result = true;
                do {result = createFolder(project.ProjectNameUnique);} while (!result);

                string filePicturePath = Path.Combine(Server.MapPath("~/File/" + project.ProjectNameUnique), filePictureName);
                file.SaveAs(filePicturePath);
            }


            project.Title = title;
            project.Comment = comment;
            project.TitleSecond = titleSecond;
            project.Type = type;
            project.MainPicturePath = "/File/" + project.ProjectNameUnique +"/"+ filePictureName;

            if (_db.AddProject(project))
                return RedirectToAction("ProjectImageAdd", new {id = project.ProjectNameUnique});

            return View();
        }

        [Authorize]
        public ActionResult ProjectImageAdd(string id)
        {
            var project = _db.GetProjectByName(id) != null ? _db.GetProjectByName(id) : new Project();

            return View(project);
        }

        [Authorize]
        [HttpPost]
        public ActionResult ProjectImageAdd(Project p)
        {

            TempData["ProjectEdit"] = _db.UpdateProject(p).ToString().ToLower();

            return RedirectToAction("projectDetail", new {id = p.ProjectNameUnique});
        }

        [Authorize]
        [HttpPost]
        public ActionResult FileUpload(IEnumerable<HttpPostedFileBase> file, string projectID)
        {
            var projectId = Convert.ToDecimal(projectID);

            var result = false;
            Project project = _db.GetProjectById(projectId);

            if (project != null)
            {
                foreach (var f in file)
                {
                    string fileName = null;

                    if (f != null)
                    {
                        fileName = Path.GetFileName(f.FileName);
                        string uploadPath = Path.Combine(Server.MapPath("~/File/"+project.ProjectNameUnique), fileName);
                        f.SaveAs(uploadPath);
                    }

                    var imageFile = new ImageFilePath
                    {
                        ProjectID = projectId,
                        ImagePath = "/File/" + project.ProjectNameUnique + "/" + fileName
                    };

                    result = _db.AddImageFilePath(imageFile);
                }
            }

            return Json(new {Message = result});
        }

        [Authorize]
        public ActionResult projectDetail(string id)
        {
            var project = _db.GetProjectByName(id) != null ? _db.GetProjectByName(id) : new Project();

            return View(project);
        }

        [Authorize]
        public JsonResult getProjectImages(string id)
        {
            decimal projectId = Convert.ToDecimal(id);

            if (_db.GetImagesByProjectId(projectId).Any())
            {
                return Json(_db.GetImagesByProjectId(projectId));
            }

            return Json("");
        }

        [Authorize]
        [HttpPost]
        public JsonResult setDeletedImages(string id)
        {
            decimal imageId = Convert.ToDecimal(id);
            ImageFilePath image = _db.GetImageFilePathById(imageId);

            deleteImage(image.ImagePath).ToString().ToLower();

            string result = _db.RemoveImageFilePath(image).ToString().ToLower();

            return Json(result);
        }

        [Authorize]
        private bool deleteImage(string path)
        {

            string filePath = Path.Combine(Server.MapPath(path));

            if (System.IO.File.Exists(@filePath))
            {
                try
                {
                    System.IO.File.Delete(@filePath);
                }
                catch (Exception e)
                {
                    return false;
                }
                return true;
            }
            return true;
        }

        [Authorize]
        private bool createFolder(string folderName)
        {
            var folderPath = HttpContext.Server.MapPath("~/File/" + folderName);

            if (!Directory.Exists(folderPath))
            {
                try
                {
                    Directory.CreateDirectory(folderPath);
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }

            return true;
        }

        public ActionResult Users()
        {
            return View(_db.GetAllAspNetUsers());
        }

        [Authorize]
        public ActionResult UserEdit(string id)
        {
            AspNetUsers user = _db.GetAspNetUserById(id);
            return View(user);
        }

        [Authorize]
        [HttpPost]
        public ActionResult UserEdit(UserApp user , string password)
        {

            AspNetUsers u = _db.GetAspNetUserById(user.Id);

            u.UserName = user.UserName;
            u.Email = user.Email;
            u.NameSoyname = user.NameSoyname;

            if (password.Length > 5)
            {
                u.PasswordHash = UserManagerApp.PasswordHasher.HashPassword(password);
            }

            TempData["editUser"] = _db.UpdateAspNetUser(u);

            return RedirectToAction("UserEdit", "Admin", new {id = u.Id});
        }

        [Authorize]
        public ActionResult CreateUser()
        {
            return View(new UserApp());
        }

        [Authorize]
        [HttpPost]
        public ActionResult CreateUser(UserApp user, string password)
        {
            UserApp userName = UserManagerApp.FindByName(user.UserName);  
                                                                                                                                 
            if (userName != null)
            {
                ModelState.AddModelError("", "Girilen Email sistemde kayıtlıdır.");
                return View();
            }
            else
            {
                IdentityResult result = UserManagerApp.Create(user, password); 

                if (result.Succeeded) 
                {
                    TempData["CreateMessage"] = "true";
                    return RedirectToAction("CreateUser","Admin");
                }
                else
                {
                    ModelState.AddModelError("", "false");
                    return View();
                }
            }
        }

        public ActionResult Mails()
        {
            return View(_db.GetAllMails());
        }

        public ActionResult MailDetail(decimal id)
        {
            return View(_db.GetMailById(id));
        }

        [HttpPost]
        public JsonResult BlockAndDelete(decimal id,string blockordelete)
        {

            DAL.DB.Mails mail = _db.GetMailById(id);

            if (blockordelete == "B")
            {
                BlockIp ip = new BlockIp()
                {
                    BlockIp1 = mail.SendFromIp
                };

                bool result = _db.AddBlockIp(ip);

                if (result)
                {
                    var mailByIp = _db.GetAllMailsByIp(mail.SendFromIp);
                    foreach (var item in mailByIp)
                    {
                        _db.RemoveMail(item);
                    }
                }

                return Json(result.ToString().ToLower());
            }
            else
            {
                return Json(_db.RemoveMail(mail).ToString().ToLower());
            }
        }

        [Authorize]
        public ActionResult SingOut()
        {
            IAuthenticationManager authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}