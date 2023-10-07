using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrontoBack.Models
{
	public class Author
	{
        public string Name { get; set; }
		public int Age { get; set; }
		public Street Street { get; set; }
		[ForeignKey(nameof(Street))]
		public int StreetId { get; set; }
		public List<BookAuthor> BookAuthors { get; set; }
		public Author()
		{
			BookAuthors = new();
		}
	}
}

