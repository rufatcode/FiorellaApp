using System;
using FrontoBack.DAL;
using FrontoBack.Models;
using FrontoBack.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontoBack.ViewComponents
{
	public class HeaderViewComponent:ViewComponent
	{
		private readonly AppDbContext _context;
        private readonly IBasketServices _basketServices;
        public HeaderViewComponent( AppDbContext context,IBasketServices basketServices)
		{
			_context = context;
			_basketServices = basketServices;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			Dictionary<string, string> data = _context.NavBars.ToDictionary(p => p.Key, p => p.Value);
			string basket= Request.Cookies["Basket"];
			if (basket==null)
			{
				ViewBag.ProductCount = 0;
				ViewBag.TotalPrice = 0;
            }
			else
			{
                List<ProductToBasket> productToBaskets = JsonConvert.DeserializeObject<List<ProductToBasket>>(basket);
                List<Product> products = _context.Products.ToList();
                ViewBag.ProductCount = productToBaskets.Sum(p => p.ProductCount);
                ViewBag.TotalPrice = productToBaskets.Sum(pb => pb.ProductCount * products.Find(p => p.Id == pb.Id).Price);
				ViewBag.Products = _basketServices.Show();
            }
           
            return View(await Task.FromResult(data));
		}
	}
}

