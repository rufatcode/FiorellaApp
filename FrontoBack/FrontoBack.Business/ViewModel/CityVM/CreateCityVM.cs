using System;
namespace FrontoBack.ViewModel.CityVM
{
	public class CreateCityVM
	{
		public string Name { get; set; }
		public int Population { get; set; }
		public int CountryId { get; set; }
        public bool IsCapital { get; set; }
        public CreateCityVM()
		{
		}
	}
}

