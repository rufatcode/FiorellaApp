using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontoBack.DAL;
using FrontoBack.Models;
using FrontoBack.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FrontoBack.Controllers
{
    public class BasketController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IAddProductService _addProduct;
        private readonly IShowBasketService _showBasketService;
        private readonly IRemoveProductService _removeProductService;
        private readonly IIncreaseProductService _increaseProductService;
        private readonly IDecreaseProductService _decreaseProductService;
        public BasketController(AppDbContext context, IAddProductService addProductService, IShowBasketService showBasketService, IRemoveProductService removeProductService, IIncreaseProductService increaseProductService, IDecreaseProductService decreaseProductService)
        {
            _context = context;
            _addProduct = addProductService;
            _showBasketService = showBasketService;
            _removeProductService = removeProductService;
            _increaseProductService = increaseProductService;
            _decreaseProductService = decreaseProductService;
        }
        
        public IActionResult Index()
        {
            string data = Request.Cookies["Basket"];
            if (data == null || data == "[]")
            {
                return RedirectToAction("Index","Product");
            }

            return View(_showBasketService.Show());
        }
        public IActionResult Basket(int id)
        {
            //Response.Cookies.Append("Test","Hello",new CookieOptions { MaxAge=TimeSpan.FromMinutes(20)});
            //HttpContext.Session.SetString("Test1", "Hi");
            //HttpContext.Session.Remove("Test1");
            Product existProduct = _context.Products.FirstOrDefault(p => p.Id == id);
            if (id == 0 || existProduct == null)
            {
                return RedirectToAction("Index","Product");
            }
            _addProduct.Add(id);
            return RedirectToAction("Index");
        }
       
        public IActionResult RemoveProduct(int id)
        {
            Product existProduct = _context.Products.FirstOrDefault(p => p.Id == id);
            if (existProduct == null || id == 0)
            {
                return Redirect("/Product/Index");
            }
            string data = Request.Cookies["Basket"];
            if (data == null)
            {
                return Redirect("/Product/Index");
            }
            _removeProductService.Remove(id, data);
            return Redirect("/Basket/Index");
        }
        public IActionResult IncreaseProduct(int id)
        {
            Product existProduct = _context.Products.FirstOrDefault(p => p.Id == id);
            if (existProduct == null || id == 0)
            {
                 return RedirectToAction("Index", "Product");
            }
            string data = Request.Cookies["Basket"];
            if (data == null)
            {
                return RedirectToAction("Index", "Product");
            }

            _increaseProductService.Increase(id, data);
            return RedirectToAction("Index");
        }
        public IActionResult DecreaseProduct(int id)
        {
            Product existProduct = _context.Products.FirstOrDefault(p => p.Id == id);
            if (existProduct == null || id == 0)
            {
                return RedirectToAction("Index", "Product");
            }
            string data = Request.Cookies["Basket"];
            if (data == null)
            {
                return RedirectToAction("Index", "Product");
            }

            _decreaseProductService.Decrease(id, data);
            return RedirectToAction("Index");
        }
    }
}

