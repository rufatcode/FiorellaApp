using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontoBack.Models;
using FrontoBack.ViewModel.AccountVM;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FrontoBack.Controllers
{
    public class AccountController : Controller
    {
        // GET: /<controller>/
        private readonly  UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AppUser appUser = new AppUser();
            appUser.UserName = registerVM.UserName;
            appUser.FullName = registerVM.FullName;
            appUser.Email = registerVM.Email;
            appUser.IsActive = true;
            IdentityResult result = await _userManager.CreateAsync(appUser,registerVM.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }
            await _userManager.AddToRoleAsync(appUser, "User");
            return RedirectToAction("Login","Account");
        }
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM,string? ReturnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AppUser appUser =await _userManager.FindByNameAsync(loginVM.UserNameOrEmail);
            
            if (appUser==null)
            {
                appUser = await _userManager.FindByEmailAsync(loginVM.UserNameOrEmail);
                if (appUser==null)
                {
                    ModelState.AddModelError("", "Something Went wrong");
                    return View();
                }
            }
            if (!appUser.IsActive)
            {
                ModelState.AddModelError("", "User is Blocked");
                return View();
            }
            var resoult = await _signInManager.PasswordSignInAsync(appUser, loginVM.Password, loginVM.Remember, true);
             if (resoult.IsLockedOut)
            {
                ModelState.AddModelError("", "User is blocked");
                return View();
            }
            
            else if (!resoult.Succeeded)
            {
                ModelState.AddModelError("", "Something went wrong");
                return View();
            }
           
            await _signInManager.SignInAsync(appUser, loginVM.Remember);
            if (ReturnUrl!=null)
            {
                return Redirect(ReturnUrl);
            }
            return Redirect("/home/index");
        }
        
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/home/index");
        }
    }
}

