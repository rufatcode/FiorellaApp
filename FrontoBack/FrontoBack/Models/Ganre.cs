using System;
using System.ComponentModel.DataAnnotations;

namespace FrontoBack.Models
{
	public class Ganre
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public List<BookGanre> BookGanres { get; set; }
		public Ganre()
		{
			BookGanres = new();
		}
	}
}

