using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrontoBack.Models
{
	public class BookImages
	{
		[Key]
		public int Id { get; set; }
		public string ImgSrc { get; set; }
		public Book Book { get; set; }
		[ForeignKey(nameof(Book))]
		public int BookId { get; set; }
		public BookImages()
		{
		}
	}
}

