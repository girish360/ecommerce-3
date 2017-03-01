using Microsoft.AspNet.Identity;
using OZ.DataModel.Identity;
using OZ.WebController.SharedBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OZ.WebController.Areas.Admin
{
    [Authorize]
    public class RoleAdminController : BackendControllerBase
    {
        public ActionResult Index()
        {
            return View(RoleManager.Roles);
        }
        [Authorize(Roles= "Administrators")]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create([Required]string name)
        {
            if(ModelState.IsValid)
            {
                IdentityResult result = await RoleManager.CreateAsync(new DataModel.Identity.AppRole(name));
                if(result.Succeeded)
                {
                    return RedirectToAction("Index");
                }else
                {
                    AddErrorsFromResult(result);                    
                }
            }
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            AppRole role = await RoleManager.FindByIdAsync(id);
            if(role != null)
            {
                IdentityResult result = await RoleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Error", result.Errors);
                }
            }
            else
            {
                return View("Error", new string[] { "Role not fount" });
            }
        }

        public async Task<ActionResult> Edit(string id)
        {
            AppRole role = await RoleManager.FindByIdAsync(id);
            string[] memberIDs = role.Users.Select(x => x.UserId).ToArray();
            IEnumerable<AppUser> members = UserManager.Users.Where(x => memberIDs.Any(y => y == x.Id));
            IEnumerable<AppUser> nonMembers = UserManager.Users.Except(members);
            return View(new RoleEditModel
            {
                Role = role,
                Members = members,
                NonMembers = nonMembers
            });
        }
        [HttpPost]
        public async Task<ActionResult> Edit(RoleModificationModel model)
        {
            IdentityResult result;
            if(ModelState.IsValid)
            {
                foreach(string userId in model.IdsToAdd ?? new string[] { })
                {
                    result = await UserManager.AddToRoleAsync(userId, model.RoleName);
                    if(!result.Succeeded)
                    {
                        return View("Error", result.Errors);
                    }
                }
                foreach(string userId in model.IdsToDelete ?? new string[] { })
                {
                    result = await UserManager.RemoveFromRoleAsync(userId, model.RoleName);
                    if(!result.Succeeded)
                    {
                        return View("Error", result.Errors);
                    }
                }
                return RedirectToAction("Index");
            }
            return View("Error", new string[] { "Role Not Found" });
        }
    }
}
