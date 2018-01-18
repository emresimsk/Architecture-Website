using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ArcWebPage.Identity
{
    public class UserAppDbContext: IdentityDbContext<UserApp>
    {
        public UserAppDbContext() : base("ArcEntitiy")
        {

        }
    }
}