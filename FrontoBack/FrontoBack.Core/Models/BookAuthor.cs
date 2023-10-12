using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FrontoBack.Core.Models;

namespace FrontoBack.Models
{
	public class BookAuthor:BaseEntity
	{
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

