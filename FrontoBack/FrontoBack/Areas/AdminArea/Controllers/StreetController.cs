using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FrontoBack.Business.Interfaces;
using FrontoBack.Business.Services;
using FrontoBack.DAL;
using FrontoBack.Models;
using FrontoBack.ViewModel.StreetVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FrontoBack.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize(Roles = "Admin,SupperAdmin")]
    public class StreetController : Controller
    {
        // GET: /<controller>/
        private readonly AppDbContext _context;
        private readonly IStreetService _streetService;
        public StreetController(AppDbContext context,IStreetService streetService)
        {
            _context = context;
            _streetService = streetService;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _streetService.GetAll();
            int n = 9;
            return View(await _streetService.GetAll());
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
            var isCreated =await _streetService.Create(createStreetVM);
             if (!isCreated)
            {
                ModelState.AddModelError("Name", "Name must bu unique");
                return View();
            }
            return RedirectToAction("Index", "Street");
        }
        [Authorize(Roles = "SupperAdmin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id==null)
            {
                return BadRequest();
            }
            var isDeleted =await _streetService.Delete(id);
            if (isDeleted==false)
            {
                return BadRequest("Something went wrong");
            }
            return RedirectToAction("Index", "Street");
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id==null)
            {
                return BadRequest();
            }
            Street street =await _streetService.GetByIdIncludeCity(id);
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
            var isModified =await  _streetService.Update(id, updateStreetVM);
            if (!isModified)
            {
                ModelState.AddModelError("Name", "Steet name must bu unique for every city");
                return View();
            }
            return RedirectToAction("Index", "Street");
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id==null)
            {
                return BadRequest();
            }
            Street street =await _streetService.GetByIdThenIncludeCountry(id);

            return View(new DetailStreetVM { Name=street.Name,City=street.City});
        }
        
    }
}

