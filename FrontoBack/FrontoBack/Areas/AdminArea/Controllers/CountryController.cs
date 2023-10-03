using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontoBack.DAL;
using FrontoBack.Models;
using FrontoBack.ViewModel.CountryVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FrontoBack.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class CountryController : Controller
    {
        private readonly AppDbContext _context;
        // GET: /<controller>/
        public CountryController(AppDbContext context)
        {
            _context = context;
        }
        public  IActionResult Index()
        {
            return View(_context.Countries.AsNoTracking().Include(c=>c.Cities).ToList());
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(CreateCountryVM createCountryVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (_context.Countries.Any(c=>c.Name.ToLower()==createCountryVM.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "Name must be unique");
                return View();
            }
            _context.Countries.Add(new Country { Name = createCountryVM.Name,Population=createCountryVM.Population }) ;
            _context.SaveChanges();
            return RedirectToAction("Index", "Country");
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id==null)
            {
                return BadRequest("Country is not exist");
            }
            Country existCountry = _context.Countries.FirstOrDefault(c => c.Id == id);
            if (existCountry==null)
            {
                return NotFound();
            }
            _context.Countries.Remove(existCountry);
            _context.SaveChangesAsync();
            return RedirectToAction("Index","Country");
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id==null)
            {
                return BadRequest("Country Is not exist");
            }
            Country existCountry = _context.Countries.FirstOrDefault(c => c.Id == id);
            if (existCountry==null)
            {
                return NotFound();
            }
            return View(new UpdateCountryVM { Name=existCountry.Name,Population=existCountry.Population});
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult>Update(int id,UpdateCountryVM updateCountryVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Country existCountry = _context.Countries.FirstOrDefault(c => c.Id == id);
            if (_context.Countries.Any(c=>c.Name.ToLower()==updateCountryVM.Name.ToLower()&&c.Name.ToLower()!=existCountry.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "Country Name must be unique");
                return View();
            }
            existCountry.Name = updateCountryVM.Name;
            existCountry.Population = updateCountryVM.Population;
            _context.SaveChangesAsync();
            return RedirectToAction("Index", "Country");
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id==null)
            {
                return BadRequest("COuntry Is not Exist");
            }
            Country existCountry = _context.Countries.AsNoTracking().Include(c=>c.Cities).FirstOrDefault(c => c.Id == id);
            if (existCountry==null)
            {
                return NotFound();
            }

            return View(existCountry);
        }
    }
}

