using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrontoBack.Models
{
	public class BookGanre
	{
		[Key]
		public int Id { get; set; }
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

