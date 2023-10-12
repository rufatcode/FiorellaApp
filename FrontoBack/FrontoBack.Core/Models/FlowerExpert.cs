using System;
using System.ComponentModel.DataAnnotations;
using FrontoBack.Core.Models;

namespace FrontoBack.Models
{
	public class FlowerExpert:BaseEntity
	{
		public string ImgSrc { get; set; }
		public string Name { get; set; }
		public string Position { get; set; }
		public FlowerExpert()
		{
		}
	}
}

