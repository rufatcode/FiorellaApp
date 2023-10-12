using System;
using Microsoft.AspNetCore.Http;

namespace FrontoBack.Areas.AdminArea.ViewModel.ProductVM
{
	public class UpdateProductVM
	{
        public IFormFile? Image { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public int CatagoryId { get; set; }
        public UpdateProductVM()
		{
		}
	}
}

