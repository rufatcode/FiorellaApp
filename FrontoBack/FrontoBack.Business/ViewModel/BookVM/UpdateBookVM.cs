using System;
namespace FrontoBack.ViewModel.BookVM
{
	public class UpdateBookVM
	{
		public string Name { get; set; }
		public int Price { get; set; }
		public int PageCount { get; set; }
        public List<int>? AuthorIds { get; set; }
        public List<int>? GanreIds { get; set; }
        public IFormFile[]? Images { get; set; }
        public UpdateBookVM()
        {
            AuthorIds = new();
            GanreIds = new();
        }
       
	}
}

