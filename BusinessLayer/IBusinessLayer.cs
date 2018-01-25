using System;                                                                            
using System.Collections.Generic;                                                       
using System.Linq;                                                                       
using System.Text;                                                                       
using System.Threading.Tasks;
using DAL.DB;


namespace BusinessLayer                                                                 
{                                                                                       
    public interface IBusinessLayer                                                     
    {
        IList<AboutMe> GetAllAboutMes();                                          // About Me
        AboutMe GetAboutMeById(decimal id);                                       // About Me
        bool AddAboutMe(params AboutMe[] aboutMe);                                // About Me
        bool UpdateAboutMe(params AboutMe[] aboutMe);                             // About Me
        bool RemoveAboutMe(params AboutMe[] aboutMe);                             // About Me


        IList<AspNetUsers> GetAllAspNetUsers();                                   // AspNetUsers
        AspNetUsers GetAspNetUserByName(string userName);                         // AspNetUsers
        AspNetUsers GetAspNetUserById(string id);                                 // AspNetUsers
        bool AddAspNetUser(params AspNetUsers[] aspNetUser);                      // AspNetUsers
        bool UpdateAspNetUser(params AspNetUsers[] aspNetUser);                   // AspNetUsers
        bool RemoveAspNetUser(params AspNetUsers[] aspNetUser);                   // AspNetUsers


        IList<ContactPage> GetAllContactPages();                                  // ContactPage
        ContactPage GetContactPageById(decimal id);                               // ContactPage
        bool AddContactPage(params ContactPage[] contactPage);                    // ContactPage
        bool UpdateContactPage(params ContactPage[] contactPage);                 // ContactPage
        bool RemoveContactPage(params ContactPage[] contactPage);                 // ContactPage


        IList<Education> GetAllEducations();                                      // Education
        Education GetEducationById(decimal id);                                   // Education
        bool AddEducation(params Education[] education);                          // Education
        bool UpdateEducation(params Education[] education);                       // Education
        bool RemoveEducation(params Education[] education);                       // Education


        IList<Project> GetAllProjects();                                          // Project
        Project GetProjectById(decimal id);                                       // Project
        Project GetProjectByName(string projectName);                             // Project
        bool AddProject(params Project[] project);                                // Project
        bool UpdateProject(params Project[] project);                             // Project
        bool RemoveProject(params Project[] project);                             // Project


        IList<ImageFilePath> GetAllImageFilePaths();                              // ImageFilePath
        IList<ImageFilePath> GetImagesByProjectId(decimal projectId);             // ImageFilePath
        ImageFilePath GetImageFilePathById(decimal id);                           // ImageFilePath
        bool AddImageFilePath(params ImageFilePath[] imageFilePath);              // ImageFilePath
        bool UpdateImageFilePath(params ImageFilePath[] imageFilePath);           // ImageFilePath
        bool RemoveImageFilePath(params ImageFilePath[] imageFilePath);           // ImageFilePath


        IList<Skills> GetAllSkilles();                                            // Skills
        Skills GetSkillsById(decimal id);                                         // Skills
        bool AddSkill(params Skills[] skills);                                    // Skills
        bool UpdateSkill(params Skills[] skills);                                 // Skills
        bool RemoveSkill(params Skills[] skills);                                 // Skills 


        IList<SocialMedia> GetAllSocialMedias();                                  // Social Media
        SocialMedia GetSocialMediaById(decimal id);                               // Social Media
        bool AddSocialMedia(params SocialMedia[] socialMedia);                    // Social Media
        bool UpdateSocialMedia(params SocialMedia[] socialMedia);                 // Social Media
        bool RemoveSocialMedia(params SocialMedia[] socialMedia);                 // Social Media


        IList<Mails> GetAllMails();                                               // Mails
        IList<Mails> GetAllMailsByIp(string ip);                                  // Mails
        Mails GetMailById(decimal id);                                            // Mails
        bool AddMail(params Mails[] mails);                                       // Mails
        bool UpdateMail(params Mails[] mails);                                    // Mails
        bool RemoveMail(params Mails[] mails);                                    // Mails      


        IList<BlockIp> GetAllBlockIps();                                          // BlockIp
        bool GetIpLast5Minute(string ip, DateTime date);                          // BlockIp
        BlockIp GetBlockIpById(decimal id);                                       // BlockIp
        bool AddBlockIp(params BlockIp[] blockIp);                                // BlockIp
        bool UpdateBlockIp(params BlockIp[] blockIp);                             // BlockIp
        bool RemoveBlockIp(params BlockIp[] blockIp);                             // BlockIp



    }
}









