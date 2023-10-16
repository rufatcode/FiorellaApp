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
using Microsoft.EntityFrameworkCore;
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
            List<Check> data = _context.Checks.Include(c => c.AppUser).Include(c => c.CheckProducts).ThenInclude(cp => cp.Product).ToList();
            return View(data);
        }
        public async Task< IActionResult> Delete(int? id)
        {
            if (id==null)
            {
                return BadRequest();
            }
            Check check =await _context.Checks.FirstOrDefaultAsync(c => c.Id == id);
            if (check==null)
            {
                return NotFound();
            }
            _context.Checks.Remove(check);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task< IActionResult> CheckOut()
        {
            if (!User.Identity.IsAuthenticated)
            {
                TempData["Warning"] = "Please Enter Personal Account for sales";
                return RedirectToAction("Login", "Account");
            }
            AppUser user =await _userManager.FindByNameAsync(User.Identity.Name);
            var domain = "http://localhost:5134/";
            var options = new SessionCreateOptions
            {
                SuccessUrl = domain + $"CheckOut/ConfirmBasket",
                CancelUrl = domain + "Account/Login",
                LineItems = new List<SessionLineItemOptions>(),
                Mode = "payment",
                CustomerEmail = user.Email,
              
                

            };
            var products = _basketServices.Show();
            foreach (var product in products)
            {
                var sessionListItem = new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = (long)(product.ProductCount * product.Price)*100,
                        Currency = "usd",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = product.Name.ToString(),
                          
                        }
                    },
                    Quantity=product.ProductCount
                };
                options.LineItems.Add(sessionListItem);
            }
            var service = new SessionService();
            Session session = service.Create(options);
            TempData["Session"] = session.Id;
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
            Check check = new();
            AppUser appUser = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);
            check.SaleTime = DateTime.Now;
            check.UserId = appUser.Id;
            double totalAmmount = 0;
            foreach (var product in productInBaskets)
            {
                
                totalAmmount += product.Price*product.ProductCount;
                Product existProduct =await _context.Products.FirstOrDefaultAsync(p => p.Id == product.Id);
               
                CheckProduct checkProduct = new() { CheckId = check.Id, ProductId = existProduct.Id, Price = existProduct.Price,ProductCount= product.ProductCount };
                check.CheckProducts.Add(checkProduct);
                existProduct.Count -= product.ProductCount;
            }
            check.TotalAmmount = totalAmmount;


            
            await _context.Checks.AddAsync(check);
            await _context.SaveChangesAsync();
            var service = new SessionService();
            Session session = service.Get(TempData["Session"].ToString());
            if (session.PaymentStatus=="Paid")
            {
                TempData["SuccessMessage"] = $"Payment successfully complated Payent ammount:{productInBaskets.Sum(p => p.Price * p.ProductCount)}$";
            }
            else
            {
                TempData["SuccessMessage"] = "Something went wrong";
            }
            
            Response.Cookies.Delete("Basket");
            return RedirectToAction("Index", "Basket");
        }
    }
}

