using System;
using System.ComponentModel.DataAnnotations;
using FrontoBack.Core.Models;

namespace FrontoBack.Models
{
	public class SliderContent:BaseEntity
	{
		public string Title { get; set; }
		public string Content { get; set; }
		public string ImgSrc { get; set; }
		public SliderContent()
		{
		}
	}
}

