using System;
using FrontoBack.Models;

namespace FrontoBack.ViewModel.BookVM
{
	public class DetailBookVM
	{
		public string Name { get; set; }
		public int Price { get; set; }
		public int PageCount { get; set; }
		public List<BookAuthor> BookAuthors { get; set; }
		public List<BookImages> BookImages { get; set; }
		public List<BookGanre> BookGanres { get; set; }
		public DetailBookVM()
		{
			BookAuthors = new();
			BookImages = new();
			BookGanres = new();
		}
	}
}

