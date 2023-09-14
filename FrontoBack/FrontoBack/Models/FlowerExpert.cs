using System;
using System.ComponentModel.DataAnnotations;

namespace FrontoBack.Models
{
	public class FlowerExpert
	{
		[Key]
		public int Id { get; set; }
		public string ImgSrc { get; set; }
		public string Name { get; set; }
		public string Position { get; set; }
		public FlowerExpert()
		{
		}
	}
}

