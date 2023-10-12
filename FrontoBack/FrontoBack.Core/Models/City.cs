using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FrontoBack.Core.Models;

namespace FrontoBack.Models
{
	public class City:BaseEntity
	{
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

