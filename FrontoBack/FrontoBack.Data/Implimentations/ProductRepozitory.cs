using System;
using FrontoBack.Core.Interfaces;
using FrontoBack.DAL;
using FrontoBack.Models;

namespace FrontoBack.Data.Implimentations
{
	public class ProductRepozitory:Repozitory<Product>, IProductRepozitory
    {
		public ProductRepozitory(AppDbContext context) : base(context)
        {
		}
	}
}

