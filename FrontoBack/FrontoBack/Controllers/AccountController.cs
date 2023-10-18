using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using FrontoBack.Business.ViewModel.AccountVM;
using FrontoBack.Models;
using FrontoBack.ViewModel.AccountVM;
using Microsoft.AspNetCore.Authorization;
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
            var token =await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
             Random verificationDigits = new Random();
             int digits=verificationDigits.Next(100000,1000000);
            var link = Url.Action(nameof(VerifyEmail), "Account", new { VerifyEmail = appUser.Email,token,verfyDigit=digits }, Request.Scheme, Request.Host.ToString());
            MailMessage mailMessage = new();
            mailMessage.From=new MailAddress("rufatri@code.edu.az", "Fiorella App");
            mailMessage.To.Add(new MailAddress(appUser.Email));
            mailMessage.Subject = "Verify Email";
            var verificationMessageBody = string.Empty;
            using(StreamReader fileStream=new StreamReader("wwwroot/Verification/VerificationEmail.html"))
            {
                verificationMessageBody =await fileStream.ReadToEndAsync();
            }
            verificationMessageBody = verificationMessageBody.Replace("{{digits}}", digits.ToString());
            verificationMessageBody = verificationMessageBody.Replace("{{link}}", link);
            verificationMessageBody = verificationMessageBody.Replace("{{userName}}", appUser.FullName);
            mailMessage.Body = verificationMessageBody;
            mailMessage.IsBodyHtml = true;
            SmtpClient smtpClient = new();
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential("rufatri@code.edu.az", "bazi tvxk bnta hymo");
            smtpClient.Send(mailMessage);
            return RedirectToAction("VerifyEmail", "Account");
        }
        public IActionResult VerifyEmail()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> VerifyEmail(string VerifyEmail, string token,int verfyDigit,int digits)
        {
            if (digits != verfyDigit)
            {
                ModelState.AddModelError("", "incorrect verification number");
                return View();
            }
            AppUser appUser =await _userManager.FindByEmailAsync(VerifyEmail);
            await _userManager.ConfirmEmailAsync(appUser, token);
            return RedirectToAction("Login");
        }
        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(string email)
        {
            AppUser appUser =await _userManager.FindByEmailAsync(email);
            if (appUser==null)
            {
                ModelState.AddModelError("Email", "Email is not valid");
                return View();
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(appUser);
            var link = Url.Action(nameof(ResetPassword), "Account",
                new {email=appUser.Email,token},Request.Scheme,Request.Host.ToString()
                );
            MailMessage mailMessage = new();
            mailMessage.From = new MailAddress("rufatri@code.edu.az", "Fiorella App");
            mailMessage.To.Add(new MailAddress(appUser.Email));
            mailMessage.Subject = "Reset Password";
            mailMessage.Body = $"<a href={link}>click here for reset account</a>";
            mailMessage.IsBodyHtml = true;
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential("rufatri@code.edu.az", "bazi tvxk bnta hymo");
            smtpClient.Send(mailMessage);
            return RedirectToAction("Index","Product");
        }
        public IActionResult ResetPassword(string token)
        {
          
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(string email,string token,ResetPasswordVM resetPasswordVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AppUser appUser =await _userManager.FindByEmailAsync(email);
           var resoult=  await _userManager.ResetPasswordAsync(appUser, token, resetPasswordVM.Password);
            if (!resoult.Succeeded)
            {
                foreach (var error in resoult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }
            await _userManager.UpdateSecurityStampAsync(appUser);
            return RedirectToAction("Login");
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
            else if (!appUser.IsActive)
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
            else if (!await _userManager.IsEmailConfirmedAsync(appUser))
            {
                ModelState.AddModelError("", "Please verify account");
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

