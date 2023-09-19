using System;
using FrontoBack.DAL;
using Microsoft.AspNetCore.Mvc;

namespace FrontoBack.ViewComponents
{
	public class AccordionViewComponent:ViewComponent
	{
		private readonly AppDbContext _context;
		public AccordionViewComponent(AppDbContext context)
		{
			_context = context;
		}
		public async Task<IViewComponentResult> InvokeAsync(int take,int skip)
		{
			var data = take != 0 && skip != 0 ? _context.Accordions
			   .Skip(skip)
			   .Take(take)
			   .ToList() :
			   take != 0 && skip == 0 ?
			   _context.Accordions
			   .Take(take)
			   .ToList() :
			   take == 0 && skip != 0 ?
			   _context.Accordions
			   .Skip(skip)
			   .ToList() :
			   _context.Accordions.ToList();
			return View(await Task.FromResult(data));
		}
	}
}

