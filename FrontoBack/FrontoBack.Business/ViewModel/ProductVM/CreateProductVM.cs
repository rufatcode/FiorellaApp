using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace FrontoBack.Areas.AdminArea.ViewModel
{
	public class CreateProductVM
	{
		public IFormFile Image { get; set; }
		public string Name { get; set; }
        [Range(0, int.MaxValue)]
        public int Price { get; set; }
		[Range(0,int.MaxValue)]
		public int Count { get; set; }
		public int CatagoryId { get; set; }
		public CreateProductVM()
		{
		}
	}
}

