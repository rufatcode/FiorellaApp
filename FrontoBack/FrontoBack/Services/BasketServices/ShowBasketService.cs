using System;
using FrontoBack.DAL;
using FrontoBack.Models;
using FrontoBack.Services.Interfaces;
using FrontoBack.ViewModel;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace FrontoBack.Services
{
	public class ShowBasketService:IShowBasketService
	{
        private readonly IHttpContextAccessor _httpContext;
        public readonly AppDbContext _context;
		public ShowBasketService(IHttpContextAccessor httpContextAccessor,AppDbContext context)
		{
            _httpContext = httpContextAccessor;
            _context = context;
		}

        public List<BasketVM> Show()
        {
            List<BasketVM> basketVM = new();
            List<ProductToBasket> productToBaskets = new();
            string data = _httpContext.HttpContext.Request.Cookies["Basket"];
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

