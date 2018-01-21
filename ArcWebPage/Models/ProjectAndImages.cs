using System.Collections.Generic;
using DAL.DB;

namespace ArcWebPage.Models
{
    public class ProjectAndImages
    {
        public Project Project { get; set; }
        public IList<ImageFilePath> Images { get; set; }
    }
}