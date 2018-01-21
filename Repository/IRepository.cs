using DAL.DB;

namespace Repository
{
    public interface IAboutmeRepository : IGenericDataRepository<AboutMe> { }
    public interface IAspNetUsersRepository : IGenericDataRepository<AspNetUsers> { }
    public interface IContactPageRepository : IGenericDataRepository<ContactPage> { }
    public interface IEducationRepository : IGenericDataRepository<Education> { }
    public interface IImageFilePathRepository : IGenericDataRepository<ImageFilePath> { }
    public interface IProjectRepository : IGenericDataRepository<Project> { }
    public interface ISkillsRepository : IGenericDataRepository<Skills> { }
    public interface ISocialMediaRepository : IGenericDataRepository<SocialMedia> { }

    
    public class AboutMeRepository : GenericDataRepository<AboutMe>, IAboutmeRepository { }
    public class AspNetUsersRepository : GenericDataRepository<AspNetUsers>, IAspNetUsersRepository { }
    public class ContactPageRepository : GenericDataRepository<ContactPage>, IContactPageRepository { }
    public class EducationRepository : GenericDataRepository<Education>, IEducationRepository { }
    public class ImageFilePathRepository : GenericDataRepository<ImageFilePath>, IImageFilePathRepository { }
    public class ProjectRepository : GenericDataRepository<Project>, IProjectRepository { }
    public class SkillsRepository : GenericDataRepository<Skills>, ISkillsRepository { }
    public class SocialMediaRepository : GenericDataRepository<SocialMedia>, ISocialMediaRepository { }
}
