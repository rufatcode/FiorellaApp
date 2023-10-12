using System;
using FrontoBack.Core.Models;

namespace FrontoBack.Models
{
	public class ProductJson:BaseEntity
	{
		public string ImgSrc { get; set; }
		public string Name { get; set; }
		public int Price { get; set; }
		public string CatagoryName { get; set; }
		public ProductJson() 
		{
		}
	}
}

