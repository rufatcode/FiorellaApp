using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontoBack.Business.ViewModel.RoleVM;
using FrontoBack.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FrontoBack.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize(Roles ="Admin,SupperAdmin")]
    public class RoleController : Controller
    {
        // GET: /<controller>/
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleController(UserManager<AppUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            List<IdentityRole> roles = _roleManager.Roles.ToList();
            
            return View(roles);
        }
        [Authorize(Roles ="SupperAdmin")]
        public async Task<IActionResult> Delete(string? id)
        {
            if (id==null)
            {
                return BadRequest();
            }
             IdentityRole role = await _roleManager.FindByIdAsync(id);
            if (role==null)
            {
                return NotFound();
            }
            else if (role.Name=="Admin"||role.Name== "SupperAdmin" || role.Name=="User")
            {
                return BadRequest();
            }
           await _roleManager.DeleteAsync(role);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Create()
        {

            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(CreateRoleVM createRoleVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else if (_roleManager.Roles.Any(r=>r.Name.ToLower()==createRoleVM.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "Role must be unique");
                return View();
            }
            await _roleManager.CreateAsync(new IdentityRole { Name = createRoleVM.Name });
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Detail(string id)
        {
            if (id==null)
            {
                return BadRequest();
            }
            var Role = _roleManager.Roles.FirstOrDefault(r => r.Id == id);
            
            if (Role==null)
            {
                return NotFound();
            }
            var Users =await _userManager.GetUsersInRoleAsync(Role.Name);
            return View(new DetailRoleVM { Role=Role.Name,Users=Users});
        }
        public async Task<IActionResult> Update(string id)
        {
            if (id==null)
            {
                return BadRequest();
            }
            IdentityRole Role = await _roleManager.Roles.FirstOrDefaultAsync(r => r.Id == id);
            if (Role==null)
            {
                return NotFound();
            }
            return View(new UpdateRoleVM { Role= Role.Name});
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(string id, UpdateRoleVM updateRoleVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else if (_roleManager.Roles.Any(r=>r.Name.ToLower()==updateRoleVM.Role.ToLower()))
            {
                ModelState.AddModelError("Role", "Role name must be unique");
                return View();
            }
            await _roleManager.DeleteAsync(_roleManager.Roles.FirstOrDefault(r=>r.Id==id));
            
            await _roleManager.CreateAsync(new IdentityRole { Name = updateRoleVM.Role });
           
            return RedirectToAction("Index");
        }
    }
}

