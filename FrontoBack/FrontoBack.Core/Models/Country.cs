using System;
using System.ComponentModel.DataAnnotations;

namespace FrontoBack.Models
{
	public class Country
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public long Population { get; set; }
		public List<City> Cities { get; set; }
		public Country()
		{
			Cities = new();
		}
	}
}

