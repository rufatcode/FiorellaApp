using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrontoBack.Models
{
	public class Accordion
	{
		[Key]
		public int Id { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		//[NotMapped]
		//public TimeOnly TimeOnly = TimeOnly.FromDateTime(DateTime.Now);
		public Accordion()
		{
		}
	}
}

