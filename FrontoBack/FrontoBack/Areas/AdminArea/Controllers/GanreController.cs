using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontoBack.DAL;
using FrontoBack.Models;
using FrontoBack.ViewModel.GanreVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FrontoBack.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class GanreController : Controller
    {
        // GET: /<controller>/
        private readonly AppDbContext _context;
        public GanreController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Ganres.Include(g=>g.BookGanres).ThenInclude(bg=>bg.Book).AsNoTracking().ToList());
        }
        public async Task<IActionResult> Create()
        {

            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(CreateGanreVM createGanreVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else if (_context.Ganres.Any(g=>g.Name.ToLower()==createGanreVM.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "Name must be unique");
                return View();
            }
            _context.Ganres.Add(new Ganre { Name = createGanreVM.Name });
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Ganre");
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id==null)
            {
                return BadRequest();
            }
            Ganre ganre = _context.Ganres.FirstOrDefault(g => g.Id == id);
            if (ganre==null)
            {
                return NotFound();
            }
            _context.Ganres.Remove(ganre);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Ganre");
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id==null)
            {
                return BadRequest();
            }
            Ganre ganre = _context.Ganres.FirstOrDefault(g => g.Id == id);
            if (ganre==null)
            {
                return NotFound();
            }

            return View(new UpdateGanreVM { Name=ganre.Name});
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(int id,UpdateGanreVM updateGanreVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Ganre ganre = _context.Ganres.FirstOrDefault(g => g.Id == id);
            if (_context.Ganres.Any(g=>g.Name.ToLower()==updateGanreVM.Name.ToLower()&&updateGanreVM.Name.ToLower()!=ganre.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "Name must be unique");
                return View();
            }
            ganre.Name = updateGanreVM.Name;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Ganre");
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id==null)
            {
                return BadRequest();
            }
            Ganre ganre = _context.Ganres.Include(g=>g.BookGanres).ThenInclude(bg=>bg.Book).AsNoTracking().FirstOrDefault(g => g.Id == id);
            if (ganre==null)
            {
                return NotFound();
            }

            return View(new DetailGanreVM { Name=ganre.Name,BookGanres=ganre.BookGanres});
        }
    }
}

