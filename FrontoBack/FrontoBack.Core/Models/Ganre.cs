using System;
using System.ComponentModel.DataAnnotations;
using FrontoBack.Core.Models;

namespace FrontoBack.Models
{
	public class Ganre:BaseEntity
    {
        public string Name { get; set; }
		public List<BookGanre> BookGanres { get; set; }
		public Ganre()
		{
			BookGanres = new();
		}
	}
}

