using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontoBack.Business.ViewModel.UserVM;
using FrontoBack.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FrontoBack.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize(Roles ="Admin,SupperAdmin")]
    public class UserController : Controller
    {
        // GET: /<controller>/
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserController(UserManager<AppUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            List<UserListVM> userListVM = new();
            var users = _userManager.Users.ToList();
            foreach (var user in users)
            {
                userListVM.Add(new UserListVM { Id = user.Id,UserName=user.UserName,Roles=await _userManager.GetRolesAsync(user) });
            }
            return View(userListVM);
        }
        public async Task<IActionResult> Detail(string id)
        {
            if (id==null)
            {
                return BadRequest();
            }
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user==null)
            {
                return NotFound();
            }
            IList<string> Roles = await _userManager.GetRolesAsync(user);
            bool isVerified=false;
            if (await _userManager.IsEmailConfirmedAsync(user))
            {
                isVerified = true;
            }
            return View(new UserDetailVM { Email=user.Email,UserName=user.UserName,Id=user.Id,Roles=Roles,FullName=user.FullName,IsActive=user.IsActive,IsVerified=isVerified});
        }
        [Authorize(Roles = "SupperAdmin")]
        public async Task<IActionResult> Delete(string  id)
        {
            if (id==null)
            {
                return BadRequest();
            }
            AppUser appUser = await _userManager.FindByIdAsync(id);
            if (appUser==null)
            {
                return NotFound();
            }
            IList<string> Roles =await _userManager.GetRolesAsync(appUser);
            foreach (var role in Roles)
            {
                if (role=="Admin"||role=="SupperAdmin")
                {
                    return BadRequest();
                }
            }
            await _userManager.DeleteAsync(appUser);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "SupperAdmin")]
        public async Task<IActionResult> Update(string id)
        {
            if (id==null)
            {
                return BadRequest();
            }
            AppUser appUser =await _userManager.FindByIdAsync(id);
            if (appUser==null)
            {
                return NotFound();
            }
            IList<string> userRoles = await _userManager.GetRolesAsync(appUser);
            foreach (var userRole in userRoles)
            {
                if (userRole == "SupperAdmin")
                {
                    return BadRequest();
                }
            }
            List<IdentityRole> allRoles =await _roleManager.Roles.ToListAsync();
            Dictionary<string, bool> RolesAndStatus = new();
            foreach (var role in allRoles)
            {
                if (userRoles.Any(u=>u.ToLower()==role.Name.ToLower()))
                {
                    RolesAndStatus.Add(role.Name, true);
                }
                else
                {
                    RolesAndStatus.Add(role.Name, false);
                }
                
            }
            ViewBag.Roles = RolesAndStatus;
            return View(new UserUpdateVM { UserName=appUser.UserName,FullName=appUser.FullName,Email=appUser.Email,Status=appUser.IsActive});
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(string id, UserUpdateVM userUpdateVM,List<string> roles)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AppUser appUser =await _userManager.FindByIdAsync(id);
            appUser.Email = userUpdateVM.Email;
            appUser.UserName = userUpdateVM.UserName;
            appUser.FullName = userUpdateVM.FullName;
            appUser.IsActive = userUpdateVM.Status;
            IList<string> activeRoles =await _userManager.GetRolesAsync(appUser);
            if (roles.Count!=0)
            {
                foreach (var role in activeRoles)
                {
                    await _userManager.RemoveFromRoleAsync(appUser, role);
                }
            }
            
            await _userManager.AddToRolesAsync(appUser, roles);
            var resoult = await _userManager.UpdateAsync(appUser);
            if (!resoult.Succeeded)
            {
                foreach (var error in resoult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }
            return RedirectToAction("Index");
        }
    }
}

