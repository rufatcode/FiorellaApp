using System;
using System.ComponentModel.DataAnnotations;
using FrontoBack.Core.Models;

namespace FrontoBack.Models
{
	public class Catagorie:BaseEntity
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public List<Product> Products { get; set; }
		public Catagorie()
		{
		}
	}
}

