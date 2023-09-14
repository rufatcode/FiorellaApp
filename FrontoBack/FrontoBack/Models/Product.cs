using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrontoBack.Models
{
	public class Product
	{
		[Key]
		public int Id { get; set; }
		public string ImgSrc { get; set; }
		public string Name { get; set; }
		public int Price { get; set; }
		[ForeignKey(nameof(Catagorie))]
		public int CatagorieId { get; set; }
		public Catagorie Catagories { get; set; }
		public Product()
		{
		}
	}
}

