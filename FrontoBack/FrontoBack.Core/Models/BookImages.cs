using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FrontoBack.Core.Models;

namespace FrontoBack.Models
{
	public class BookImages:BaseEntity
	{
		public string ImgSrc { get; set; }
		public Book Book { get; set; }
		[ForeignKey(nameof(Book))]
		public int BookId { get; set; }
		public BookImages()
		{
		}
	}
}

