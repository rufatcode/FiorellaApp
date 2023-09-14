using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontoBack.DAL;
using FrontoBack.Models;
using FrontoBack.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FrontoBack.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _appDbContext { get; set; }
        private HomeVM _homeVM { get; set; }
        // GET: /<controller>/
        public HomeController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _homeVM = new();
        }
        public IActionResult Index()
        {
            _homeVM.Sliders = _appDbContext.Sliders.ToList();
            _homeVM.SliderContent = _appDbContext.SliderContents.FirstOrDefault(item => item.Id ==1);
            _homeVM.Catagories = _appDbContext.Catagories.Include(c => c.Products).ToList();
            _homeVM.FlowerExperts = _appDbContext.FlowerExperts.ToList();
            _homeVM.Blogs = _appDbContext.Blogs.ToList();
            return View(_homeVM);
        }
    }
}

