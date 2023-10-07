using System;
using System.ComponentModel.DataAnnotations;

namespace FrontoBack.Models
{
	public class Catagorie
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public List<Product> Products { get; set; }
		public Catagorie()
		{
		}
	}
}

