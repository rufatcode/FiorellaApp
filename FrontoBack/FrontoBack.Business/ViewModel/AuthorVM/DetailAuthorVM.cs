using System;
using FrontoBack.Models;

namespace FrontoBack.ViewModel.AuthorVM
{
	public class DetailAuthorVM
	{
		public string Name { get; set; }
		public int Age { get; set; }
		public Street Street { get; set; }
		public List<BookAuthor> BookAuthors { get; set; }
		public DetailAuthorVM()
		{
            BookAuthors = new();
		}
	}
}

