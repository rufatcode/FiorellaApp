using System;
using FrontoBack.DAL;
using FrontoBack.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontoBack.ViewComponents
{
	public class HeaderViewComponent:ViewComponent
	{
		private readonly AppDbContext _context;
		public HeaderViewComponent( AppDbContext context)
		{
			_context = context;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			Dictionary<string, string> data = _context.NavBars.ToDictionary(p => p.Key, p => p.Value);
			List<ProductToBasket> productToBaskets = JsonConvert.DeserializeObject<List<ProductToBasket>>(Request.Cookies["Basket"]);
			List<Product> products = _context.Products.ToList();
            ViewBag.ProductCount = productToBaskets.Sum(p=>p.ProductCount);
			ViewBag.TotalPrice = productToBaskets.Sum(pb => pb.ProductCount *products.Find(p=>p.Id==pb.Id).Price);
            return View(await Task.FromResult(data));
		}
	}
}

