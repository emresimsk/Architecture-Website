using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace ArcWebPage.Identity
{
    public class UserManagerApp : UserManager<UserApp>
    {
        public UserManagerApp(IUserStore<UserApp> store) : base(store)
        {
        }

        public static UserManagerApp Create(IdentityFactoryOptions<UserManagerApp> idetityFactoryOptions,
            IOwinContext owinContext)
        {
            var context = owinContext.Get<UserAppDbContext>();

            var user = new UserManagerApp(new UserStore<UserApp>(context));

            var userValidator = new UserValidator<UserApp>(user)
            {
                RequireUniqueEmail = true,
                AllowOnlyAlphanumericUserNames = true
            };

            user.UserValidator = userValidator;

            return user;
        }
    }
}