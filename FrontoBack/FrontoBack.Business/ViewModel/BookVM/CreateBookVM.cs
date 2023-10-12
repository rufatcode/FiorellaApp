using System;
using Microsoft.AspNetCore.Http;

namespace FrontoBack.ViewModel.BookVM
{
	public class CreateBookVM
	{
		public string Name { get; set; }
		public int Price { get; set; }
		public int PageCount { get; set; }
		public List<int> AuthorIds { get; set; }
		public List<int> GanreIds { get; set; }
		public IFormFile[] Images { get; set; }
		public CreateBookVM()
		{
			AuthorIds = new();
			GanreIds = new();
		}
	}
}

