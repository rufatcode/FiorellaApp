using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontoBack.DAL;
using FrontoBack.Models;
using FrontoBack.Services.Interfaces;
using FrontoBack.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FrontoBack.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.Length = _context.Products.ToList().Count;
            List<Product> products = _context.Products
                .Select(p => p)
                .Take(2)
                .ToList();
            return View(products);
        }
        public IActionResult ShowMore(int skip)
        {
            
            List<Product> products = _context.Products
                .Select(p => p)
                .Skip(skip)
                .Take(2)
                .ToList();
            return PartialView("_ProductPartial",products);
        }
        public IActionResult Product(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            Product product = _context.Products
                .FirstOrDefault(x => x.Id == id);
            if (product==null)
            {
                return NotFound();
            }
            return View(id);
        }
        public IActionResult Search(string value)
        {
            List<Product> products = _context.Products
                .Where(p => p.Name.Contains(value))
                .ToList();
                
            return PartialView("_ProductSearchPartial",products);
        }
       
        public IActionResult Test()
        {
            List<Product> products = _context.Products
                .Include(p => p.Catagories)
                .ToList();

            var data = _context.ChangeTracker.Entries().ToList();
            List<ProductJson> productJsons = new();

            //return Ok(new

            //{
            //    ImgSrc=products.ImgSrc,
            //    Name=products.Name,
            //    Price=products.Price,
            //    CatagoryName=products.Catagories.Name
            //});
            //return Ok(new ProductJson { ImgSrc=products.ImgSrc,Name=products.Name,Price=products.Price,CatagoryName=products.Catagories.Name});

            //foreach (var item in products)
            //{
            //    productJsons.Add(new() {ImgSrc=item.ImgSrc,Name=item.Name,Price=item.Price,CatagoryName=item.Catagories.Name });
            //}


            //return Ok(productJsons);

            List<ProductJson> productJsons1 = _context.Products
                .Select(p => new ProductJson { ImgSrc = p.ImgSrc, Name = p.Name, Price = p.Price, CatagoryName = p.Catagories.Name })
                .ToList();
            var dataTracking = _context.ChangeTracker.Entries().ToList();

            return Ok(productJsons1);
        }
    }
}

