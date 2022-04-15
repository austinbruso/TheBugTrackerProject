using BugTrackerProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBugTrackerProject.Extensions;
using TheBugTrackerProject.Models.ViewModel;
using TheBugTrackerProject.Services.Interfaces;

namespace TheBugTrackerProject.Controllers
{

    [Authorize]
    public class UserRolesController : Controller
    {
       private readonly IBTRolesService _rolesService;
       private readonly IBTCompanyInfoService _companyInfoService;

        public UserRolesController(IBTRolesService rolesService, IBTCompanyInfoService companyInfoService)
        {
            _rolesService = rolesService;
            _companyInfoService = companyInfoService;
        }

        [HttpGet]
        public async Task<IActionResult> ManageUserRoles()
        {
            //Add an instance of the ViewModel as a List (model)
            List<ManageUserRolesViewModel> model = new();

            //Get Company Id
            int companyId = User.Identity.GetCompanyId().Value;

            //Get all company users
            List<BTUser> users = await _companyInfoService.GetAllMembersAsync(companyId);

            foreach(BTUser user in users)
            {
                ManageUserRolesViewModel viewModel = new();
                viewModel.BTUser = user;
                IEnumerable<string> selected = await _rolesService.GetUserRolesAsync(user);
                viewModel.Roles = new MultiSelectList(await _rolesService.GetRolesAsync(), "Name", "Name", selected);

                model.Add(viewModel);
            }

            return View(model);
        }

        [HttpPost] 
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManageUserRoles(ManageUserRolesViewModel member)
        {
            // Get the company id
            int companyId = User.Identity.GetCompanyId().Value;

            //Instiatiate the BTUser
            BTUser btUser = (await _companyInfoService.GetAllMembersAsync(companyId)).FirstOrDefault(u => u.Id == member.BTUser.Id);

            //Get the roles for the USer
            IEnumerable<string> roles = await _rolesService.GetUserRolesAsync(btUser);

            //Grab the selected role
            string userRole = member.SelectedRoles.FirstOrDefault();

            if(!string.IsNullOrEmpty(userRole))
            {
                //Remove user from their roles
                if (await _rolesService.RemoveUserFromRolesAsync(btUser, roles))
                {
                    await _rolesService.AddUserToRoleAsync(btUser, userRole);
                }

            }

            return RedirectToAction(nameof(ManageUserRoles));
        }

    }
}
