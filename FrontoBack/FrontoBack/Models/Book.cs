using System;
using System.ComponentModel.DataAnnotations;

namespace FrontoBack.Models
{
	public class Book
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public int Price { get; set; }
		public int PageCount { get; set; }
		public List<BookAuthor> BookAuthors { get; set; }
		public List<BookGanre> BookGanres { get; set; }
		public List<BookImages> BookImages { get; set; }
		public Book()
		{
			BookAuthors = new();
			BookGanres = new();
			BookImages = new();
		}
	}
}

