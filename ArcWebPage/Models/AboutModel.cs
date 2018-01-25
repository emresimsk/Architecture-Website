using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.DB;

namespace ArcWebPage.Models
{
    public class AboutModel
    {
        public AboutMe About { get; set; }
        public IEnumerable<Skills> Skills { get; set; }
        public IEnumerable<Education> Education { get; set; }
    }
}