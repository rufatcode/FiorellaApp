using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontoBack.Core.Models;
using FrontoBack.DAL;
using FrontoBack.Models;
using FrontoBack.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FrontoBack.Controllers
{
    public class CheckOutController : Controller
    {
        // GET: /<controller>/
        private readonly AppDbContext _context;
        private readonly IBasketServices _basketServices;
        private readonly UserManager<AppUser> _userManager;
        public CheckOutController(AppDbContext context,IBasketServices basketServices,UserManager<AppUser> userManager)
        {
            _context = context;
            _basketServices = basketServices;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CheckOut()
        {
            var domain = "http://localhost:5131/";
            var options = new SessionCreateOptions
            {
                SuccessUrl=domain+$"CheckOut/OrderConfirimation",
                CancelUrl=domain+ "Account/Login",
                LineItems=new List<SessionLineItemOptions>(),
                Mode="payment"
                

            };
            var products = _context.Products.ToList();
            foreach (var product in products)
            {
                var sessionListItem = new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = (long)(product.Count * product.Price),
                        Currency = "inr",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = product.Name.ToString(),
                        }
                    },
                    Quantity=2
                };
                options.LineItems.Add(sessionListItem);
            }
            var service = new SessionService();
            Session session = service.Create(options);
            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);
        }
        public async Task<IActionResult> ConfirmBasket()
        {
            var productInBaskets = _basketServices.Show();
            if (productInBaskets.Count==0)
            {
                return RedirectToAction("Index", "Basket");
            }
            var Products = _context.Products.ToList();
            foreach (var productInBasket in productInBaskets)
            {
                if (Products.Any(p=>p.Id==productInBasket.Id&&p.Count<productInBasket.ProductCount))
                {
                    TempData["AlertMessage"] = $"{productInBasket.Name} count is {Products.FirstOrDefault(p=>p.Id==productInBasket.Id).Count} in stock";
                    return RedirectToAction("Index", "Basket");
                }
            }
            foreach (var product in productInBaskets)
            {
                Product existProduct = _context.Products.FirstOrDefault(p => p.Id == product.Id);
                existProduct.Count -= product.ProductCount;
                _context.SaveChanges();
            }
            Check check = new();
            AppUser appUser = _userManager.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            check.SaleTime = DateTime.Now;
            check.Total = productInBaskets.Sum(p => p.Price * p.ProductCount);
            check.UserId = appUser.Id;
            _context.Checks.Add(check);
            TempData["SuccessMessage"] = $"Payment successfully complated Payent ammount:{productInBaskets.Sum(p=>p.Price*p.ProductCount)}$";
            Response.Cookies.Delete("Basket");
            return RedirectToAction("Index", "Basket");
        }
    }
}

