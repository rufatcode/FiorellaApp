using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using FrontoBack.Areas.AdminArea.Helper;
using FrontoBack.DAL;
using FrontoBack.Models;
using FrontoBack.ViewModel.BookVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FrontoBack.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize(Roles = "Admin,SupperAdmin")]
    public class BookController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BookController(AppDbContext context,IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<Book> books = _context.Books
                .Include(b => b.BookAuthors)
                .ThenInclude(ba => ba.Author)
                .Include(b => b.BookGanres)
                .ThenInclude(bg => bg.Ganre)
                .Include(b => b.BookImages)
                .AsNoTracking()
                .ToList();
            return View(books);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Authors = new SelectList(_context.Authors.AsNoTracking().ToList(), "Id", "Name");
            ViewBag.Ganres = new SelectList(_context.Ganres.AsNoTracking().ToList(), "Id", "Name");
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(CreateBookVM createBookVM)
        {
            ViewBag.Authors = new SelectList(_context.Authors.AsNoTracking().ToList(), "Id", "Name");
            ViewBag.Ganres = new SelectList(_context.Ganres.AsNoTracking().ToList(), "Id", "Name");
            if (!ModelState.IsValid)
            {
                return View();
            }
            else if (_context.Books.Any(b=>b.Name.ToLower()==createBookVM.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "Book Name must be unique");
                return View();
            }
            Book book = new();
            foreach (var ganreId in createBookVM.GanreIds)
            {
                book.BookGanres.Add(new BookGanre { BookId=book.Id,GanreId=ganreId});
            }
            foreach (var authorId in createBookVM.AuthorIds)
            {
                book.BookAuthors.Add(new BookAuthor { BookId=book.Id,AuthorId=authorId});
            }
            for (int i = 0; i < createBookVM.Images.Length; i++)
            {
                if (!createBookVM.Images[i].IsImage())
                {
                    ModelState.AddModelError("Images", "you can choose only image");
                    return View();
                }
                else if (!createBookVM.Images[i].IsLenghSuit(1000))
                {
                    ModelState.AddModelError("Images", "you can choose image only smaller size than 1kb");
                    return View();
                }
                string fileName = Guid.NewGuid().ToString() + createBookVM.Images[i].FileName;
                string path = Path.Combine(_webHostEnvironment.WebRootPath, "img", fileName);
                using(FileStream stream=new FileStream(path, FileMode.Create))
                {
                    createBookVM.Images[i].CopyTo(stream);
                }
                book.BookImages.Add(new BookImages { BookId = book.Id, ImgSrc = fileName });
            }
           
            
            book.Name = createBookVM.Name;
            book.Price = createBookVM.Price;
            book.PageCount = createBookVM.PageCount;
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Book");
        }
        [Authorize(Roles = "SupperAdmin")]
        public async Task<IActionResult> Delete(int ?id)
        {
            if (id==null)
            {
                return BadRequest();
            }
            Book book = _context.Books.FirstOrDefault(b => b.Id == id);
            if (book==null)
            {
                return NotFound();
            }
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Book");
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id==null)
            {
                return BadRequest();
            }
            Book book = _context.Books.FirstOrDefault(b => b.Id == id);
            if (book==null)
            {
                return NotFound();
            }
            ViewBag.Authors = new SelectList(_context.Authors.AsNoTracking().ToList(), "Id", "Name");
            ViewBag.Ganres = new SelectList(_context.Ganres.AsNoTracking().ToList(), "Id", "Name");
            UpdateBookVM updateBookVM = new();
            updateBookVM.Name = book.Name;
            updateBookVM.PageCount = book.PageCount;
            updateBookVM.Price = book.Price;
            return View(new UpdateBookVM { Name = book.Name, Price = book.Price, PageCount = book.PageCount });
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(int id, UpdateBookVM updateBookVM)
        {
            ViewBag.Authors = new SelectList(_context.Authors.AsNoTracking().ToList(), "Id", "Name");
            ViewBag.Ganres = new SelectList(_context.Ganres.AsNoTracking().ToList(), "Id", "Name");
            if (!ModelState.IsValid)
            {
                return View();
            }
            Book newBook = _context.Books
                .Include(b=>b.BookImages)
                .Include(b=>b.BookAuthors)
                .Include(b=>b.BookGanres)
                .FirstOrDefault(b => b.Id == id);
            if (_context.Books.Any(b=>b.Name.ToLower()==updateBookVM.Name.ToLower()&&b.Name.ToLower()!=newBook.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "Name must bu unique");
                return View();
            }
            int count = 0;
            foreach (var authorIds in updateBookVM.AuthorIds)
            {
                if (count==0)
                {
                    newBook.BookAuthors = new();
                }
                newBook.BookAuthors.Add(new BookAuthor { BookId = newBook.Id, AuthorId = authorIds });
                count++;
            }
            count = 0;
            foreach (var ganreIds in updateBookVM.GanreIds)
            {
                if (count==0)
                {
                    newBook.BookGanres = new();
                }
                newBook.BookGanres.Add(new BookGanre { BookId = newBook.Id, GanreId = ganreIds });
                count++;
            }
            count = 0;
            if (updateBookVM.Images!=null)
            {
                foreach (var image in updateBookVM.Images)
                {
                    if (!image.IsImage())
                    {
                        ModelState.AddModelError("Image", "Only Image");
                        return View();
                    }
                    else if (!image.IsLenghSuit(1000))
                    {
                        ModelState.AddModelError("Image", "size must be smaller than 1 kb");
                        return View();
                    }
                    string fileName = Guid.NewGuid().ToString() + image.FileName;
                    string path = Path.Combine(_webHostEnvironment.WebRootPath, "img", fileName);
                    using (FileStream stream = new FileStream(path, FileMode.Create))
                    {
                        image.CopyTo(stream);
                    }

                    if (count == 0)
                    {
                        
                        foreach (var activeImage in newBook.BookImages)
                        {
                            System.IO.File.Delete(Path.Combine(_webHostEnvironment.WebRootPath, "img", activeImage.ImgSrc));
                        }
                        newBook.BookImages = new();
                    }
                    count++;
                    newBook.BookImages.Add(new BookImages { ImgSrc = fileName, BookId = newBook.Id });

                }
            }
            
            newBook.Name = updateBookVM.Name;
            newBook.PageCount = updateBookVM.PageCount;
            newBook.Price = updateBookVM.Price;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Book");
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id==null)
            {
                return BadRequest();
            }
            Book book = _context.Books
                .Include(b=>b.BookAuthors)
                .ThenInclude(ba=>ba.Author)
                .Include(b=>b.BookGanres)
                .ThenInclude(bg=>bg.Ganre)
                .Include(b=>b.BookImages)
                .FirstOrDefault(b => b.Id == id);
            return View(new DetailBookVM { Name=book.Name,Price=book.Price,PageCount=book.PageCount,BookGanres=book.BookGanres,BookAuthors=book.BookAuthors,BookImages=book.BookImages});
        }
    }
}

