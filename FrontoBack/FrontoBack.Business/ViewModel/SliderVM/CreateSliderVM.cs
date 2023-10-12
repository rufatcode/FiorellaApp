using System;
using Microsoft.AspNetCore.Http;

namespace FrontoBack.Areas.AdminArea.ViewModel
{
	public class CreateSliderVM
	{
		public IFormFile Image { get; set; }
		public CreateSliderVM()
		{
		}
	}
}

