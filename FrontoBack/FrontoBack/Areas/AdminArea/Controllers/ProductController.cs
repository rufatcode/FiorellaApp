using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using FrontoBack.Areas.AdminArea.Helper;
using FrontoBack.Areas.AdminArea.ViewModel;
using FrontoBack.Areas.AdminArea.ViewModel.ProductVM;
using FrontoBack.DAL;
using FrontoBack.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FrontoBack.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize(Roles = "Admin,SupperAdmin")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(AppDbContext context,IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {

            return View(_context.Products.Include(p=>p.Catagories).ToList());
        }
        public IActionResult Create()
        {
            ViewBag.Catagories = _context.Catagories.ToList();
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(CreateProductVM createProductVM)
        {
            ViewBag.Catagories = _context.Catagories.ToList();
            if (!ModelState.IsValid)
            {
                return View();
            }
            else if (_context.Products.Any(p=>p.Name.ToLower()==createProductVM.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "Name must be unique");
                return View();
            }
            else if (!createProductVM.Image.IsImage())
            {
                ModelState.AddModelError("Image", "only image");
                return View();
            }
            else if (!createProductVM.Image.IsLenghSuit(1000))
            {
                ModelState.AddModelError("Image", "Length of file must be smaller than 1kb");
                return View();
            }
            
            string fileName = Guid.NewGuid().ToString() + createProductVM.Image.FileName;
            string path = Path.Combine(_webHostEnvironment.WebRootPath,"img", fileName);
            using (FileStream stream=new FileStream(path, FileMode.Create))
            {
                createProductVM.Image.CopyTo(stream);
            }
            _context.Products.Add(new Product { ImgSrc = fileName, Name = createProductVM.Name, Price = createProductVM.Price,CatagorieId=createProductVM.CatagoryId,Count=createProductVM.Count });
            _context.SaveChanges();
            return RedirectToAction("Index", "Product");
        }
        [Authorize(Roles = "SupperAdmin")]
        public IActionResult Delete(int? id)
        {
            if (id==null)
            {
                return BadRequest("something went wrong");
            }
            Product product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product==null)
            {
                return NotFound();
            }
            System.IO.File.Delete(Path.Combine(_webHostEnvironment.WebRootPath, "img", product.ImgSrc));
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index","Product");
        }

        public IActionResult Detail(int?id)
        {
            if (id==null)
            {
                return NotFound();
            }
            Product product = _context.Products.Include(p=>p.Catagories).FirstOrDefault(p => p.Id == id);
            if (product==null)
            {
                return BadRequest();
            }
            return View(product);
        }
        public IActionResult Update(int ?id)
        {
            if (id==null)
            {
                return BadRequest();
            }
            Product product = _context.Products.Include(p=>p.Catagories).FirstOrDefault(p => p.Id == id);
            if (product==null)
            {
                return NotFound();
            }
            ViewBag.Catagories = _context.Catagories.ToList();
            ViewBag.Imgsrc = product.ImgSrc;
            return View(new UpdateProductVM { Name=product.Name,Price=product.Price,CatagoryId=product.CatagorieId,Count=product.Count});
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(int id,UpdateProductVM updateProductVM)
        {
            ViewBag.Catagories = _context.Catagories.ToList();
            Product existProduct = _context.Products.FirstOrDefault(p => p.Id == id);
            ViewBag.Imgsrc = existProduct.ImgSrc;
            if (!ModelState.IsValid)
            {
                return View();
            }
            else if (updateProductVM.Image!=null)
            {
                if (!updateProductVM.Image.IsImage())
                {
                    ModelState.AddModelError("Image", "Only Image");
                }
                else if (!updateProductVM.Image.IsLenghSuit(1000))
                {
                    return View();
                }
                string fileName = Guid.NewGuid().ToString() + updateProductVM.Image.FileName;
                string path = Path.Combine(_webHostEnvironment.WebRootPath, "img", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    updateProductVM.Image.CopyTo(stream);
                }
                System.IO.File.Delete(Path.Combine(_webHostEnvironment.WebRootPath, "img", existProduct.ImgSrc));
                existProduct.ImgSrc = fileName;
            }
            
           
            if (_context.Products.Any(p=>p.Name.ToLower()==updateProductVM.Name.ToLower()&&updateProductVM.Name.ToLower()!=existProduct.Name.ToLower()))
            {
                ModelState.AddModelError("Name","Name is exist");
                return View();
            }
          
            existProduct.Name = updateProductVM.Name;
            existProduct.Price = updateProductVM.Price;
            existProduct.CatagorieId = updateProductVM.CatagoryId;
            existProduct.Count = updateProductVM.Count;
            _context.SaveChanges();

            return RedirectToAction("Index", "Product");
        }
    }
}

