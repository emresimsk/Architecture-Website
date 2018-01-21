using Microsoft.AspNet.Identity.EntityFramework;

namespace ArcWebPage.Identity
{
    public class RoleApp : IdentityRole
    {
        public RoleApp()
        {
        }

        public RoleApp(string name) : base(name)
        {
        }
    }
}