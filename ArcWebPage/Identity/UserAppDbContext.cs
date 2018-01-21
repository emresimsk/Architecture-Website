using Microsoft.AspNet.Identity.EntityFramework;

namespace ArcWebPage.Identity
{
    public class UserAppDbContext : IdentityDbContext<UserApp>
    {
        public UserAppDbContext() : base("ArcEntitiy")
        {
        }
    }
}