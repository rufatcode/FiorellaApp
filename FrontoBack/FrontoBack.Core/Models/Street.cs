using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrontoBack.Models
{
	public class Street
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		[ForeignKey(nameof(City))]
		public int CityId { get; set; }
		public City City { get; set; }
		public List<Author> Authors { get; set; }
		public Street()
		{
			Authors = new();
		}
	}
}

