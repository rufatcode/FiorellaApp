using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FrontoBack.Core.Models;

namespace FrontoBack.Models
{
	public class Product:BaseEntity
	{
		public string ImgSrc { get; set; }
		public string Name { get; set; }
		public int Price { get; set; }
		public int Count { get; set; }
		[ForeignKey(nameof(Catagorie))]
		public int CatagorieId { get; set; }
		public Catagorie Catagories { get; set; }
		public List<CheckProduct> CheckProducts { get; set; }
		public Product()
		{
		}
	}
}

