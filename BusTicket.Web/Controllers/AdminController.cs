using BusTicket.Business.Abstract;
using BusTicket.Data.Identity;
using BusTicket.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [HttpPost]
        public async Task<IActionResult> UpdateRole(string id, string name)
        {

            var role = await _roleManager.FindByIdAsync(id);
            role.Name = name;

            await _roleManager.UpdateAsync(role);


            return RedirectToAction("RoleList");
        }

        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            await _roleManager.DeleteAsync(role);
            return RedirectToAction("RoleList");
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

            return View(usersWithRoles);
        }
        public async Task<IActionResult> EditUserDetails(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            EditUserDetailsModel editUserDetails = new()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                UserName = user.UserName,
                LastName = user.LastName,
                Email = user.Email
            };

            return View(editUserDetails);
        }

        [HttpPost]
        public async Task<IActionResult> EditUserDetails(EditUserDetailsModel editUserDetails)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(editUserDetails.Id);
                user.FirstName = editUserDetails.FirstName;
                user.LastName = editUserDetails.LastName;
                user.Email = editUserDetails.Email;
                user.UserName = editUserDetails.UserName;

                await _userManager.UpdateAsync(user);

                return RedirectToAction("UserList");
            }
            return View(editUserDetails);
        }

        public async Task<IActionResult> DeleteUser(string id)
        {

            var user = await _userManager.FindByIdAsync(id);
            await _userManager.DeleteAsync(user);

            return RedirectToAction("UserList");

        }


        public async Task<IActionResult> CreateUser()
        {
            ViewBag.Roles = await _roleManager.Roles.ToListAsync();
            CreateUserModel createUserModel = new();
            return View(createUserModel);
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserModel createUserModel)
        {
            if (ModelState.IsValid)
            {
                var user = new User()
                {
                    UserName = createUserModel.UserName,
                    Email = createUserModel.Email,
                    FirstName = createUserModel.FirstName,
                    LastName = createUserModel.LastName
                };

                var result = await _userManager.CreateAsync(user, createUserModel.Password);
                if (result.Succeeded)
                {
                   await _userManager.AddToRolesAsync(user, createUserModel.SelectedRoles);
                }
                return RedirectToAction("UserList");
            }
            ViewBag.Roles = await _roleManager.Roles.ToListAsync();
            return View(createUserModel);
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
                    if (!editUserRolesModel.SelectedRoles.Contains(currentRole)) await _userManager.RemoveFromRoleAsync(user, currentRole);
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
