using System;
using System.ComponentModel.DataAnnotations;

namespace FrontoBack.Models
{
	public class Slider
	{
		[Key]
		public int Id { get; set; }
		public string ImgSrc { get; set; }
		public Slider()
		{
		}
	}
}

