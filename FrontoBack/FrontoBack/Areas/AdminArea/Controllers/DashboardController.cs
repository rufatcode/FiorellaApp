using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FrontoBack.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class DashboardController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Icon()
        {
            return View();
        }
        public IActionResult Button()
        {
            return View();
        }
        public IActionResult BasicElements()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Login2()
        {
            return View();
        }
        public IActionResult Table()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Register2()
        {
            return View();
        }
        public IActionResult Typography()
        {
            return View();
        }
        public IActionResult LockScreen()
        {
            return View();
        }
        public IActionResult Cart()
        {
            return View();
        }
        public IActionResult Documentation()
        {
            return View();
        }
    }
}

