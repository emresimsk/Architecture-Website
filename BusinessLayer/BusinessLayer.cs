using DAL.DB;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BusinessLayer:IBusinessLayer
    {


        private readonly IAboutmeRepository _aboutmeRepository;
        private readonly IAspNetUsersRepository _aspNetUsersRepository;
        private readonly IContactPageRepository _contactPageRepository;
        private readonly IEducationRepository _educationRepository;
        private readonly IImageFilePathRepository _imageFilePathRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly ISkillsRepository _skillsRepository;
        private readonly ISocialMediaRepository _socialMediaRepository;

        public BusinessLayer()
        {
            _aboutmeRepository = new AboutMeRepository();
            _aspNetUsersRepository = new AspNetUsersRepository();
            _contactPageRepository = new ContactPageRepository();
            _educationRepository = new EducationRepository();
            _imageFilePathRepository = new ImageFilePathRepository();
            _projectRepository = new ProjectRepository();
            _skillsRepository = new SkillsRepository();
            _socialMediaRepository = new SocialMediaRepository();
        }

        //<------------------------------------------------------------------ ABOUT ME ---------------------------------------------------------------->

        public IList<AboutMe> GetAllAboutMes()
        {
           return _aboutmeRepository.GetAll();
        }

        public AboutMe GetAboutMeById(decimal id)
        {
            return _aboutmeRepository.GetSingle(x=>x.Id == id);
        }

        public bool AddAboutMe(params AboutMe[] aboutMe)
        {
            return (_aboutmeRepository.Add(aboutMe) == 1);
        }

        public bool UpdateAboutMe(params AboutMe[] aboutMe)
        {
            return (_aboutmeRepository.Update(aboutMe) == 1);
        }

        public bool RemoveAboutMe(params AboutMe[] aboutMe)
        {
            return (_aboutmeRepository.Remove(aboutMe) == 1);
        }

        //<------------------------------------------------------------------ ASPNET USERS ---------------------------------------------------------------->

        public IList<AspNetUsers> GetAllAspNetUsers()
        {
            return _aspNetUsersRepository.GetAll();
        }

        public AspNetUsers GetAspNetUserByName(string userName)
        {
            return _aspNetUsersRepository.GetSingle(x => x.UserName == userName);
        }

        public bool AddAspNetUser(params AspNetUsers[] aspNetUser)
        {
            return (_aspNetUsersRepository.Add(aspNetUser) == 1);
        }

        public bool UpdateAspNetUser(params AspNetUsers[] aspNetUser)
        {
            return (_aspNetUsersRepository.Update(aspNetUser) == 1);
        }

        public bool RemoveAspNetUser(params AspNetUsers[] aspNetUser)
        {
            return (_aspNetUsersRepository.Remove(aspNetUser) == 1);
        }

        //<------------------------------------------------------------------- CONTACT PAGE ---------------------------------------------------------------->

        public IList<ContactPage> GetAllContactPages()
        {
            return _contactPageRepository.GetAll();
        }

        public ContactPage GetContactPageById(decimal id)
        {
            return _contactPageRepository.GetSingle(x => x.Id == id);
        }

        public bool AddContactPage(params ContactPage[] contactPage)
        {
            return (_contactPageRepository.Add(contactPage) == 1);
        }

        public bool UpdateContactPage(params ContactPage[] contactPage)
        {
            return (_contactPageRepository.Update(contactPage) == 1);
        }

        public bool RemoveContactPage(params ContactPage[] contactPage)
        {
            return (_contactPageRepository.Remove(contactPage) == 1);
        }

        //<------------------------------------------------------------------- EDUCATION PAGE ---------------------------------------------------------------->

        public IList<Education> GetAllEducations()
        {
            return _educationRepository.GetAll();
        }

        public Education GetEducationById(decimal id)
        {
            return _educationRepository.GetSingle(x => x.Id == id);
        }

        public bool AddEducation(params Education[] education)
        {
            return (_educationRepository.Add(education) == 1);
        }

        public bool UpdateEducation(params Education[] education)
        {
            return (_educationRepository.Add(education) == 1);
        }

        public bool RemoveEducation(params Education[] education)
        {
            return (_educationRepository.Add(education) == 1);
        }

        //<------------------------------------------------------------------- PROJECT PAGE ---------------------------------------------------------------->

        public IList<Project> GetAllProjects()
        {
            return _projectRepository.GetAll();
        }

        public Project GetProjectById(decimal id)
        {
            return _projectRepository.GetSingle(x => x.Id == id);
        }

        public Project GetProjectByName(string projectName)
        {
            return _projectRepository.GetSingle(x => x.ProjectNameUnique == projectName);
        }

        public bool AddProject(params Project[] project)
        {
            return (_projectRepository.Add(project) == 1);
        }

        public bool UpdateProject(params Project[] project)
        {
            return (_projectRepository.Update(project) == 1);
        }

        public bool RemoveProject(params Project[] project)
        {
            return (_projectRepository.Remove(project) == 1);
        }

        //<------------------------------------------------------------------- IMAGES FILE PATH ---------------------------------------------------------------->

        public IList<ImageFilePath> GetAllImageFilePaths()
        {
            return _imageFilePathRepository.GetAll();
        }

        public IList<ImageFilePath> GetImagesByProjectId(decimal projectId)
        {
            return _imageFilePathRepository.GetList(x => x.ProjectID == projectId);
        }

        public ImageFilePath GetImageFilePathById(decimal id)
        {
            return _imageFilePathRepository.GetSingle(x => x.Id == id);
        }

        public bool AddImageFilePath(params ImageFilePath[] imageFilePath)
        {
            return (_imageFilePathRepository.Add(imageFilePath) == 1);
        }

        public bool UpdateImageFilePath(params ImageFilePath[] imageFilePath)
        {
            return (_imageFilePathRepository.Update(imageFilePath) == 1);
        }

        public bool RemoveImageFilePath(params ImageFilePath[] imageFilePath)
        {
            return (_imageFilePathRepository.Remove(imageFilePath) == 1);
        }

        //<------------------------------------------------------------------- SKİLLS ---------------------------------------------------------------->

        public IList<Skills> GetAllSkilles()
        {
            return _skillsRepository.GetAll();
        }

        public Skills GetSkillsById(decimal id)
        {
            return _skillsRepository.GetSingle(x => x.Id == id);
        }

        public bool AddSkill(params Skills[] skills)
        {
            return (_skillsRepository.Add(skills)==1);
        }

        public bool UpdateSkill(params Skills[] skills)
        {
            return (_skillsRepository.Update(skills) == 1);
        }

        public bool RemoveSkill(params Skills[] skills)
        {
            return (_skillsRepository.Remove(skills) == 1);
        }

        //<------------------------------------------------------------------- SOCIAL MEDIA ---------------------------------------------------------------->

        public IList<SocialMedia> GetAllSocialMedias()
        {
            return _socialMediaRepository.GetAll();
        }

        public SocialMedia GetSocialMediaById(decimal id)
        {
            return _socialMediaRepository.GetSingle(x => x.Id == id);
        }

        public bool AddSocialMedia(params SocialMedia[] socialMedia)
        {
            return (_socialMediaRepository.Add() == 1);
        }

        public bool UpdateSocialMedia(params SocialMedia[] socialMedia)
        {
            return (_socialMediaRepository.Update() == 1);
        }

        public bool RemoveSocialMedia(params SocialMedia[] socialMedia)
        {
            return (_socialMediaRepository.Remove() == 1);
        }

        
    }
}
