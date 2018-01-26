using System.Collections.Generic;
using DAL.DB;

namespace ArcWebPage.Models
{
    public class ContactModel
    {
        public ContactPage Contact { get; set; }
        public IEnumerable<SocialMedia> Sociales { get; set; }
    }
}