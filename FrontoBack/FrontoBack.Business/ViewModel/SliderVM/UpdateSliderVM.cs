using System;
using Microsoft.AspNetCore.Http;

namespace FrontoBack.Areas.AdminArea.ViewModel.SliderVM
{
	public class UpdateSliderVM
	{
		public IFormFile Image { get; set; }
		public UpdateSliderVM()
		{
		}
	}
}

