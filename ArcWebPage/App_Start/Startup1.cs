using System;
using System.Threading.Tasks;
using ArcWebPage.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(ArcWebPage.App_Start.Startup1))]

namespace ArcWebPage.App_Start
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<UserAppDbContext>(() => new UserAppDbContext());
            app.CreatePerOwinContext<UserManagerApp>(UserManagerApp.Create);
            app.CreatePerOwinContext<RoleAppManager>(RoleAppManager.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Home/Admin")
            });
        }
    }
}
