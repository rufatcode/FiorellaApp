using System;
using System.ComponentModel.DataAnnotations;
using FrontoBack.Core.Models;

namespace FrontoBack.Models
{
	public class NavBar:BaseEntity
	{
		public string Key { get; set; }
		public string Value { get; set; }
		public NavBar()
		{
		}
	}
}

