using System;
using FrontoBack.DAL;
using Microsoft.AspNetCore.Mvc;

namespace FrontoBack.ViewComponents
{
	public class FooterViewComponent:ViewComponent
	{
		private readonly AppDbContext _context;
		
		public FooterViewComponent(AppDbContext context)
		{
			_context = context;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			Dictionary<string, string> data = _context.NavBars.ToDictionary(p => p.Key, p => p.Value);
			return View(await Task.FromResult(data));
		}
	}
}

