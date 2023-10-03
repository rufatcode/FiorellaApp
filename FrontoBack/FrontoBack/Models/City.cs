using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrontoBack.Models
{
	public class City
	{
		[Key]
		public  int Id { get; set; }
		public string Name { get; set; }
		public int Population { get; set; }
		[ForeignKey(nameof(Country))]
		public int CountryId { get; set; }
		public Country Country { get; set; }
		public List<Street> Streets { get; set; }
		public bool IsCapital { get; set; }
		public City()
		{
			Streets = new();
		}
	}
}

