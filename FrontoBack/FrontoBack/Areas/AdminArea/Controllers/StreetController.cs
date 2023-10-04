using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FrontoBack.DAL;
using FrontoBack.Models;
using FrontoBack.ViewModel.StreetVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FrontoBack.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class StreetController : Controller
    {
        // GET: /<controller>/
        private readonly AppDbContext _context;
        public StreetController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Streets.AsNoTracking().Include(s=>s.City).ToList());
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Cities = new SelectList(_context.Cities.ToList(), "Id", "Name");
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(CreateStreetVM createStreetVM)
        {
            ViewBag.Cities = new SelectList(_context.Cities.ToList(), "Id", "Name");
            if (!ModelState.IsValid)
            {
                return View();
            }
            else if (_context.Streets.Any(s=>s.Name.ToLower()==createStreetVM.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "Name must bu unique");
                return View();
            }
             _context.Streets.Add(new Street { Name = createStreetVM.Name, CityId = createStreetVM.CityId });
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Street");
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id==null)
            {
                return BadRequest();
            }
            Street street = _context.Streets.FirstOrDefault(s => s.Id == id);
            if (street==null)
            {
                return NotFound();
            }
            _context.Streets.Remove(street);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Street");
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id==null)
            {
                return BadRequest();
            }
            Street street = _context.Streets.Include(s=>s.City).FirstOrDefault(s => s.Id == id);
            if (street==null)
            {
                return NotFound();
            }
            return View(new UpdateStreetVM {Name=street.Name });
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(int id,UpdateStreetVM updateStreetVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Street street = _context.Streets.Include(s => s.City).FirstOrDefault(s => s.Id == id);
            if (_context.Streets.Any(s => s.Name.ToLower() == updateStreetVM.Name.ToLower() && s.CityId == street.CityId&&updateStreetVM.Name!=street.Name))
            {
                ModelState.AddModelError("Name", "Steet name must bu unique for every city");
                return View();
            }
            street.Name = updateStreetVM.Name;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Street");
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id==null)
            {
                return BadRequest();
            }
            Street street = _context.Streets.Include(s=>s.City).ThenInclude(c=>c.Country).FirstOrDefault(s => s.Id == id);
            if (street==null)
            {
                return NotFound();
            }

            return View(new DetailStreetVM { Name=street.Name,City=street.City});
        }
        
    }
}

