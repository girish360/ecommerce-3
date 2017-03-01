using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OZ.DataModel.Identity;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using OZ.IdentityServices.Identity;

namespace OZ.WebController.SharedBase
{
    public abstract class BackendControllerBase : ControllerBase
    {
        public BackendControllerBase()
        {
            ViewBag.CurrentUserName = HttpContext == null ? "NO":  CurrentUser.UserName;
        }
        public AppUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            }
        }
        public IAuthenticationManager AuthManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        public AppRoleManager RoleManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<AppRoleManager>();
            }            
        }
        public void AddErrorsFromResult(IdentityResult result)
        {
            foreach (string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        public AppUser CurrentUser
        {
            get
            { return UserManager.FindByName(HttpContext.User.Identity.Name); }
        }
    }
}
