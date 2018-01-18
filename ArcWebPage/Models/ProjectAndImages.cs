using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace ArcWebPage.Models
{
    public class ProjectAndImages
    {
        public Project Project { get; set; }
        public IList<ImageFilePath> Images { get; set; }
    }
}