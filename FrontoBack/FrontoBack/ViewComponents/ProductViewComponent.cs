using System;
using FrontoBack.DAL;
using Microsoft.AspNetCore.Mvc;

namespace FrontoBack.ViewComponents
{
	public class ProductViewComponent:ViewComponent
	{
		private readonly AppDbContext _context;
		public ProductViewComponent(AppDbContext context)
		{
			_context = context;
		}
		public async Task<IViewComponentResult> InvokeAsync(int id)
		{
			var data=_context.Products
				.FirstOrDefault(p=>p.Id==id);
			return View(await Task.FromResult(data));
		}
	}
}

