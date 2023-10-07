using System;
using System.ComponentModel.DataAnnotations;

namespace FrontoBack.Areas.AdminArea.ViewModel
{
	public class UpdateCatagoryVM
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[MaxLength(100)]
		public string Description { get; set; }
		public UpdateCatagoryVM()
		{
		}
	}
}

