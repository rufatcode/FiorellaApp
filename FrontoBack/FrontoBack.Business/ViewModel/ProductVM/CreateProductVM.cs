using System;
namespace FrontoBack.Areas.AdminArea.ViewModel
{
	public class CreateProductVM
	{
		public IFormFile Image { get; set; }
		public string Name { get; set; }
		public int Price { get; set; }
		public int CatagoryId { get; set; }
		public CreateProductVM()
		{
		}
	}
}

