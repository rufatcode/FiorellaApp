using System;
using System.ComponentModel.DataAnnotations;

namespace FrontoBack.Models
{
	public class Ganre
    {
        public string Name { get; set; }
		public List<BookGanre> BookGanres { get; set; }
		public Ganre()
		{
			BookGanres = new();
		}
	}
}

