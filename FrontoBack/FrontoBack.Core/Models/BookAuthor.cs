using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrontoBack.Models
{
	public class BookAuthor
	{
		[Key]
		public int Id { get; set; }
		public Book Book { get; set; }
		public Author Author { get; set; }
		[ForeignKey(nameof(Author))]
		public int AuthorId { get; set; }
		[ForeignKey(nameof(Book))]
		public int BookId { get; set; }
		public BookAuthor()
		{
		}
	}
}

