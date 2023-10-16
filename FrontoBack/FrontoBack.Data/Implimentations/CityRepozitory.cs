using System;
using FrontoBack.Core.Interfaces;
using FrontoBack.DAL;
using FrontoBack.Models;

namespace FrontoBack.Data.Implimentations
{
	public class CityRepozitory:Repozitory<City>, ICityRepozitory
    {
		public CityRepozitory(AppDbContext context) : base(context)
        {
		}
	}
}

