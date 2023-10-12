using System;
using System.ComponentModel.DataAnnotations;
using FrontoBack.Core.Models;

namespace FrontoBack.Models
{
	public class Slider:BaseEntity
	{
		public string ImgSrc { get; set; }
		public Slider()
		{
		}
	}
}

