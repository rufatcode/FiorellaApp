using System;
using System.ComponentModel.DataAnnotations;

namespace FrontoBack.Models
{
	public class NavBar
	{
		[Key]
		public int Id { get; set; }
		public string Key { get; set; }
		public string Value { get; set; }
		public NavBar()
		{
		}
	}
}

