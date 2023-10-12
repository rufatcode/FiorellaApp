using System;
using System.Net.Http.Json;
using FrontoBack.DAL;
using FrontoBack.Models;
using FrontoBack.ViewModel;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
namespace FrontoBack.Services
{
	public class BasketServices:IBasketServices
	{
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AppDbContext _context;
        public BasketServices(IHttpContextAccessor httpContextAccessor,AppDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }
        
        public void Add(int id)
        {
            List<ProductToBasket> products = new();
            string data = _httpContextAccessor.HttpContext.Request.Cookies["Basket"];
            if (data == null)
            {
                _httpContextAccessor.HttpContext.Response.Cookies.Append("Basket", JsonConvert.SerializeObject(products), new CookieOptions { MaxAge = TimeSpan.FromDays(1) });
            }
            else
            {
                products = JsonConvert.DeserializeObject<List<ProductToBasket>>(data);
            }
            if (products.Find(p => p.Id == id) != null)
            {
                products.Find(p => p.Id == id).ProductCount++;
            }
            else
            {
                products.Add(new() { Id = id, ProductCount = 1 });
            }

            _httpContextAccessor.HttpContext.Response.Cookies.Append("Basket", JsonConvert.SerializeObject(products));
        }
        public void Decrease(int id, string data)
        {
            List<ProductToBasket> productToBaskets = JsonConvert.DeserializeObject<List<ProductToBasket>>(data);
            if (productToBaskets.Find(p => p.Id == id).ProductCount == 1)
            {
                Remove(id, data);

            }
            else
            {
                productToBaskets.Find(p => p.Id == id).ProductCount--;
                _httpContextAccessor.HttpContext.Response.Cookies.Append("Basket", JsonConvert.SerializeObject(productToBaskets), new CookieOptions { MaxAge = TimeSpan.FromDays(1) });

            }
        }
        public void Increase(int id, string data)
        {
            List<ProductToBasket> productToBaskets = JsonConvert.DeserializeObject<List<ProductToBasket>>(data);
            productToBaskets.Find(p => p.Id == id).ProductCount++;
            _httpContextAccessor.HttpContext.Response.Cookies.Append("Basket", JsonConvert.SerializeObject(productToBaskets), new CookieOptions { MaxAge = TimeSpan.FromDays(1) });
        }
        public void Remove(int id, string data)
        {
            List<ProductToBasket> products = JsonConvert.DeserializeObject<List<ProductToBasket>>(data);
            products.Remove(products.Find(p => p.Id == id));
            _httpContextAccessor.HttpContext.Response.Cookies.Append("Basket", JsonConvert.SerializeObject(products), new CookieOptions { MaxAge = TimeSpan.FromDays(1) });
        }
        public List<BasketVM> Show()
        {
            List<BasketVM> basketVM = new();
            List<ProductToBasket> productToBaskets = new();
            string data = _httpContextAccessor.HttpContext.Request.Cookies["Basket"];
            if (data==null)
            {
                return basketVM;
            }
            productToBaskets = JsonConvert.DeserializeObject<List<ProductToBasket>>(data);
            foreach (var item in productToBaskets)
            {
                Product exisctProduct = _context.Products.FirstOrDefault(p => p.Id == item.Id);
                basketVM.Add(new() { Id = exisctProduct.Id, Name = exisctProduct.Name, ImgSrc = exisctProduct.ImgSrc, Price = exisctProduct.Price, ProductCount = item.ProductCount });
            }
            return basketVM;
        }
    }
}

