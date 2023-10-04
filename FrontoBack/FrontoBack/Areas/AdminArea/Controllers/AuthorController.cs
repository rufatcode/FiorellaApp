using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontoBack.DAL;
using FrontoBack.Models;
using FrontoBack.ViewModel.AuthorVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FrontoBack.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class AuthorController : Controller
    {
        // GET: /<controller>/
        private readonly AppDbContext _context;
        public AuthorController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            return View(_context.Authors.Include(a=>a.BookAuthors).ThenInclude(ba=>ba.Book).Include(a=>a.Street).ThenInclude(s=>s.City).ThenInclude(c=>c.Country).AsNoTracking().ToList());
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Streets = new SelectList(_context.Streets.ToList(), "Id", "Name");
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(CreateAuthorVM createAuthorVM)
        {
            ViewBag.Streets = new SelectList(_context.Streets.ToList(), "Id", "Name");
            if (!ModelState.IsValid)
            {
                return View();
            }
            else if (_context.Authors.Any(a=>a.Name==createAuthorVM.Name))
            {
                ModelState.AddModelError("Name", "Name must be unique");
                return View();
            }
            _context.Authors.Add(new Author { Name=createAuthorVM.Name,Age=createAuthorVM.Age,StreetId=createAuthorVM.StreetId});
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Author");
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id==null)
            {
                return BadRequest();
            }
            Author author = _context.Authors.FirstOrDefault(a => a.Id == id);
            if (author==null)
            {
                return NotFound();
            }
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Author");
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id==null)
            {
                return BadRequest();
            }
            Author author = _context.Authors.FirstOrDefault(a => a.Id == id);
            if (author==null)
            {
                return NotFound();
            }
            ViewBag.Streets = new SelectList(_context.Streets.ToList(), "Id", "Name");
            return View(new UpdateAuthorVM { Age=author.Age,StreetId=author.StreetId});
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(int id,UpdateAuthorVM updateAuthorVM)
        {
            ViewBag.Streets = new SelectList(_context.Streets.ToList(), "Id", "Name");
            if (!ModelState.IsValid)
            {
                return View();
            }
            Author author = _context.Authors.FirstOrDefault(a => a.Id == id);
            author.Age = updateAuthorVM.Age;
            author.StreetId = updateAuthorVM.StreetId;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Author");
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id==null)
            {
                return BadRequest();
            }
            Author author = _context.Authors.Include(a => a.Street).ThenInclude(s => s.City).ThenInclude(c => c.Country).Include(a => a.BookAuthors).ThenInclude(ba => ba.Book).AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (author==null)
            {
                return NotFound();
            }
            return View(new DetailAuthorVM { Name=author.Name,Age=author.Age,Street=author.Street, BookAuthors = author.BookAuthors});
        }
    }
}

