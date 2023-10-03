using System;
using System.ComponentModel.DataAnnotations;

namespace FrontoBack.Areas.AdminArea.ViewModel
{
	public class CreateCatagoryVM
	{
		[Required]
		public string Name { get; set; }
		[MaxLength(100)]
		public string Description { get; set; }
		public CreateCatagoryVM()
		{
		}
	}
}

