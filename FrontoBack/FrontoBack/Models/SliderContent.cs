using System;
using System.ComponentModel.DataAnnotations;

namespace FrontoBack.Models
{
	public class SliderContent
	{
		[Key]
		public int Id { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public string ImgSrc { get; set; }
		public SliderContent()
		{
		}
	}
}

