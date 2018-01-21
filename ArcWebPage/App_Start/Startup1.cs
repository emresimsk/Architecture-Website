using ArcWebPage.App_Start;
using ArcWebPage.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(Startup1))]

namespace ArcWebPage.App_Start
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(() => new UserAppDbContext());
            app.CreatePerOwinContext<UserManagerApp>(UserManagerApp.Create);
            app.CreatePerOwinContext<RoleAppManager>(RoleAppManager.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Home/Admin")
            });
        }
    }
}