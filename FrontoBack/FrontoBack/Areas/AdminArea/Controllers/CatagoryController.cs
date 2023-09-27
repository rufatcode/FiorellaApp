using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontoBack.Areas.AdminArea.ViewModel;
using FrontoBack.DAL;
using FrontoBack.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FrontoBack.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class CatagoryController : Controller
    {
        private readonly AppDbContext _context;
        public CatagoryController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Catagories.ToList());
        }
        public IActionResult Detail(int ?id)
        {
            if (id==null)
            {
                return BadRequest();
            }
            Catagorie catagorie = _context.Catagories.FirstOrDefault(c => c.Id == id);
            if (catagorie==null)
            {
                return NotFound();
            }
            return View(catagorie);
        }
        public IActionResult Delete(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            Catagorie catagorie = _context.Catagories.FirstOrDefault(c => c.Id == id);
            if (catagorie==null)
            {
                return NotFound();
            }
            _context.Catagories.Remove(catagorie);
            _context.SaveChanges();
            return RedirectToAction("Index","Catagory");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(CreateCatagoryVM createCatagoryVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Catagorie existCatagory = _context.Catagories.FirstOrDefault(c => c.Name.ToLower().Contains(createCatagoryVM.Name.ToLower()));
            if (existCatagory!=null)
            {
                ModelState.AddModelError("Name", "Name is not valid");
                return View();
            }
            _context.Catagories.Add(new Catagorie { Name = createCatagoryVM.Name, Description = createCatagoryVM.Description });
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Update(int ?id)
        {
            if (id==null)
            {
                return BadRequest();
            }
            Catagorie catagorie = _context.Catagories.FirstOrDefault(c => c.Id == id);
            if (catagorie==null)
            {
                return NotFound();
            }

            return View(new UpdateCatagoryVM { Id=catagorie.Id,Name=catagorie.Name, Description = catagorie.Description});
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(UpdateCatagoryVM updateCatagoryVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Catagorie existCatagorie = _context.Catagories.FirstOrDefault(c => c.Id == updateCatagoryVM.Id);
            if (_context.Catagories.ToList().Any(c=>c.Name.ToLower()==updateCatagoryVM.Name.ToLower()&&c.Id!=updateCatagoryVM.Id))
            {
                ModelState.AddModelError("Name", "Name is not valid");
                return View();
            }
            else if (existCatagorie.Description == updateCatagoryVM.Description&&existCatagorie.Name==updateCatagoryVM.Name)
            {
                ModelState.AddModelError("Description", "Description is some");
                return View();
            }
            
            existCatagorie.Name = updateCatagoryVM.Name;
            existCatagorie.Description = updateCatagoryVM.Description;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

