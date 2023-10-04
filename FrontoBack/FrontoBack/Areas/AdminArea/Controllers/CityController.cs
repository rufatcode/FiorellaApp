using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontoBack.DAL;
using FrontoBack.Models;
using FrontoBack.ViewModel.CityVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FrontoBack.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class CityController : Controller
    {
        // GET: /<controller>/
        private readonly AppDbContext _context;
        public CityController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Cities.AsNoTracking().Include(c=>c.Country).ToList());
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Countries = new SelectList(_context.Countries.ToList(), "Id", "Name");
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(CreateCityVM createCityVM)
        {
            ViewBag.Countries = new SelectList(_context.Countries.ToList(), "Id", "Name");
            if (!ModelState.IsValid)
            {
                return View();
            }
            else if (_context.Cities.Any(c=>c.Name.ToLower()==createCityVM.Name.ToLower()&&c.CountryId==createCityVM.CountryId))
            {
                ModelState.AddModelError("Name", "City must be unique for each countiries");
                return View();
            }
            else if (_context.Cities.Any(c=>c.CountryId==createCityVM.CountryId&&c.IsCapital))
            {
                createCityVM.IsCapital = false;
            }
            _context.Cities.Add(new City { CountryId = createCityVM.CountryId, Name = createCityVM.Name, Population = createCityVM.Population, IsCapital = createCityVM.IsCapital });
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "City");
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id==null)
            {
                return BadRequest();
            }
            City existCity = _context.Cities.FirstOrDefault(c => c.Id == id);
            if (existCity==null)
            {
                return NotFound();
            }
            _context.Cities.Remove(existCity);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index","City");
        }
        public async Task<IActionResult> Update(int ?id)
        {
            if (id==null)
            {
                return BadRequest();
            }
            City existCity = _context.Cities.FirstOrDefault(c => c.Id == id);
            if (existCity==null)
            {
                return NotFound();
            }
            return View(new UpdateCityVM { Name=existCity.Name,Population=existCity.Population,IsCapital=existCity.IsCapital});
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(int id,UpdateCityVM updateCityVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            City existCity = _context.Cities.FirstOrDefault(c => c.Id == id);

            if (_context.Cities.Any(c=>c.Name.ToLower()==updateCityVM.Name.ToLower()&&updateCityVM.Name.ToLower()!=existCity.Name.ToLower()&&c.CountryId==existCity.CountryId))
            {
                ModelState.AddModelError("Name", "Name must be unique for every country");
                return View();
            }
            else if (updateCityVM.IsCapital)
            {
                if (_context.Cities.Any(c=>c.IsCapital&&c.CountryId==existCity.CountryId))
                {
                    updateCityVM.IsCapital = false;
                }
            }
            existCity.Name = updateCityVM.Name;
            existCity.Population = updateCityVM.Population;
            existCity.IsCapital = updateCityVM.IsCapital;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "City");
        }
        public async Task<IActionResult> Detail(int?id)
        {
            if (id==null)
            {
                return BadRequest();
            }
            City existCity = await _context.Cities.AsNoTracking().Include(c=>c.Country).Include(c=>c.Streets).FirstOrDefaultAsync(c => c.Id == id);
            if (existCity==null)
            {
                return NotFound();
            }
            return View(existCity);
        }
    }
}

