using System;
using FrontoBack.Core.Models;

namespace FrontoBack.Models
{
	public class ProductToBasket:BaseEntity
	{
		public int ProductCount { get; set; }
		public ProductToBasket()
		{
		}
	}
}

