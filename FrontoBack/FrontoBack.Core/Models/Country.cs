using System;
using System.ComponentModel.DataAnnotations;
using FrontoBack.Core.Models;

namespace FrontoBack.Models
{
	public class Country:BaseEntity
	{
		public string Name { get; set; }
		public long Population { get; set; }
		public List<City> Cities { get; set; }
		public Country()
		{
			Cities = new();
		}
	}
}

