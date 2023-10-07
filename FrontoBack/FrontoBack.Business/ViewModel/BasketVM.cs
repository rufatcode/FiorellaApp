using System;
namespace FrontoBack.ViewModel
{
	public class BasketVM
	{
		public int Id { get; set; }
		public int ProductCount { get; set; }
		public string Name { get; set; }
		public string ImgSrc { get; set; }
		public int Price { get; set; }
		public BasketVM()
		{
		}
	}
}

