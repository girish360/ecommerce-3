using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using OZ.DataModel.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ.IdentityServices.Identity
{
    public class AppIdentityDbContext:IdentityDbContext<AppUser>
    {
        public AppIdentityDbContext() : base("SqlServerIdentityContext") { }
        static AppIdentityDbContext()
        {
            Database.SetInitializer<AppIdentityDbContext>(new IdentityDbInit());
            //Database.SetInitializer<AppIdentityDbContext>(null);
            
        }
        public static AppIdentityDbContext Create()
        {
            return new AppIdentityDbContext();
        }
    }

    public class IdentityDbInit:NullDatabaseInitializer<AppIdentityDbContext>
    {

    }
}
