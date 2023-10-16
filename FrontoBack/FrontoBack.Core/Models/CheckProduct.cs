using System;
using System.ComponentModel.DataAnnotations.Schema;
using FrontoBack.Models;

namespace FrontoBack.Core.Models
{
	public class CheckProduct
	{
		public int Id { get; set; }
		[ForeignKey(nameof(Product))]
		public int ProductId { get; set; }
		public Product Product { get; set; }
		[ForeignKey(nameof(Check))]
		public int CheckId { get; set; }
		public Check Check { get; set; }
		public double Price { get; set; }
		public int ProductCount { get; set; }
		public CheckProduct()
		{
		}
	}
}

