using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FrontoBack.Core.Models;

namespace FrontoBack.Models
{
	public class BookGanre:BaseEntity
	{
		public Book Book { get; set; }
		public Ganre Ganre { get; set; }
		[ForeignKey(nameof(Book))]
		public int BookId { get; set; }
		[ForeignKey(nameof(Ganre))]
		public int GanreId { get; set; }
		public BookGanre()
		{
		}
	}
}

