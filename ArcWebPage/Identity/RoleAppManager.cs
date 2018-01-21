using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace ArcWebPage.Identity
{
    public class RoleAppManager : RoleManager<RoleApp>
    {
        public RoleAppManager(IRoleStore<RoleApp, string> store) : base(store)
        {
        }

        public static RoleAppManager Create(IdentityFactoryOptions<RoleAppManager> idetityFactoryOptions,
            IOwinContext owinContext)
        {
            var context = owinContext.Get<UserAppDbContext>();
            var role = new RoleAppManager(new RoleStore<RoleApp>(context));

            return role;
        }
    }
}