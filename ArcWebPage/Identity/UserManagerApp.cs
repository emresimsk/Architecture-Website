using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        public static UserManagerApp Create(IdentityFactoryOptions<UserManagerApp> idetityFactoryOptions, IOwinContext owinContext)
        {

            UserAppDbContext context = owinContext.Get<UserAppDbContext>();

            UserManagerApp user = new UserManagerApp(new UserStore<UserApp>(context));

            UserValidator<UserApp> userValidator = new UserValidator<UserApp>(user)
            {
                RequireUniqueEmail = true,
                AllowOnlyAlphanumericUserNames = true,
            };

            user.UserValidator = userValidator;

            return user;
        }
    }
}