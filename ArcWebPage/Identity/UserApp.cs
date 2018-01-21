using Microsoft.AspNet.Identity.EntityFramework;

namespace ArcWebPage.Identity
{
    public class UserApp : IdentityUser
    {
        public string NameSoyname { get; set; }
    }
}