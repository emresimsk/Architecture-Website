using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ArcWebPage.Identity
{
    public class RoleApp :IdentityRole
    {
        public RoleApp() : base()
        {

        }

        public RoleApp(string name) : base(name)
        {

        }
    }
}