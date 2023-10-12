using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FrontoBack.Core.Models;

namespace FrontoBack.Models
{
	public class Accordion:BaseEntity
	{
		public string Title { get; set; }
		public string Content { get; set; }
		//[NotMapped]
		//public TimeOnly TimeOnly = TimeOnly.FromDateTime(DateTime.Now);
		public Accordion()
		{

		}
	}
}

