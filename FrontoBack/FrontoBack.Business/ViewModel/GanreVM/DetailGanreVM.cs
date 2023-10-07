using System;
using FrontoBack.Models;

namespace FrontoBack.ViewModel.GanreVM
{
	public class DetailGanreVM
	{
		public string Name { get; set; }
		public List<BookGanre> BookGanres { get; set; }
		public DetailGanreVM()
		{
			BookGanres = new();
		}
	}
}

