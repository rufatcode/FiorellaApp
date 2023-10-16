using System;
using FrontoBack.Core.Interfaces;
using FrontoBack.DAL;
using FrontoBack.Models;

namespace FrontoBack.Data.Implimentations
{
	public class ProductToBasketRepozitory:Repozitory<ProductToBasket>, IProductToBasketRepozitory
    {
		public ProductToBasketRepozitory(AppDbContext context) : base(context)
        {
		}
	}
}

