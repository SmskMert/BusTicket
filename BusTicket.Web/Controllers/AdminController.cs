using BusTicket.Business.Abstract;
using BusTicket.Data.Identity;
using BusTicket.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BusTicket.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ITripService _tripService;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;



        public AdminController(ITripService tripService, RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _tripService = tripService;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        #region RoleActions
        public IActionResult RoleList()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }

        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleModel roleModel)
        {
            if (ModelState.IsValid)
            {
                var role = new IdentityRole()
                {
                    Name = roleModel.Name
                };
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("RoleList");
                }
            };
            return View(roleModel);
        }
        #endregion

        #region UserActions
        public async Task<IActionResult> UserList()
        {
            var users = _userManager.Users;
            var usersWithRoles = new List<UserWithRolesModel>();
            foreach (var user in users)
            {
                usersWithRoles.Add(
                    new UserWithRolesModel
                    {
                        UserId = user.Id,
                        UserName = user.UserName,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        Roles = await _userManager.GetRolesAsync(user)
                    });
            }
            // var UsersWithRoles = users
            //     .Select(
            //     user => new UserWithRolesModel
            //     {
            //         UserId = user.Id,
            //         UserName = user.UserName,
            //         FirstName = user.FirstName,
            //         LastName = user.LastName,
            //         Email = user.Email,
            //         Role = await _userManager.GetRolesAsync(user)
            //     }
            //);


            return View(usersWithRoles);
        }

        public async Task<IActionResult> EditUserRoles(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return RedirectToAction("UserList");
            }
            var userRoles = await _userManager.GetRolesAsync(user);
            var roles = _roleManager.Roles;
            ViewBag.Roles = roles;

            var editUserRolesModel = new EditUserRolesModel()
            {
                UserId = id,
                UserName = user.UserName,
                UserRoles = userRoles
            };
            return View(editUserRolesModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditUserRoles(EditUserRolesModel editUserRolesModel)
        {
            var user = await _userManager.FindByIdAsync(editUserRolesModel.UserId);
            var userRoles = await _userManager.GetRolesAsync(user);
            if (ModelState.IsValid)
            {
                foreach (var NewRole in editUserRolesModel.SelectedRoles)
                {
                if (!userRoles.Contains(NewRole)) await _userManager.AddToRoleAsync(user, NewRole);
                }
                foreach (var currentRole in userRoles)
                {
                    if (!editUserRolesModel.SelectedRoles.Contains(currentRole)) await _userManager.RemoveFromRoleAsync(user,currentRole);
                }
                return RedirectToAction("UserList");
            }
            var roles = _roleManager.Roles;
            ViewBag.Roles = roles;
            editUserRolesModel.UserRoles = userRoles;
            editUserRolesModel.UserName = user.UserName;
            return View(editUserRolesModel);
        }

        #endregion
    }
}
