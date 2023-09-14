using System;
using FrontoBack.Models;

namespace FrontoBack.ViewModel
{
	public class HomeVM
	{
		public List<Slider> Sliders { get; set; }
		public SliderContent SliderContent { get; set; }
		public List<Catagorie> Catagories { get; set; }
		public List<Product> Products { get; set; }
		public List<FlowerExpert> FlowerExperts { get; set; }
		public List<Blog> Blogs { get; set; }
		public HomeVM()
		{
			Sliders = new List<Slider>();
			SliderContent = new();
			Catagories = new List<Catagorie>();
			Products = new List<Product>();
			FlowerExperts = new List<FlowerExpert>();
			Blogs = new List<Blog>();
		}
	}
}

