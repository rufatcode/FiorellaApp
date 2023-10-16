using System;
using FrontoBack.Core.Interfaces;
using FrontoBack.DAL;
using FrontoBack.Models;

namespace FrontoBack.Data.Implimentations
{
	public class CountryRepozitory:Repozitory<Country>, ICountryRepozitory
    {
		public CountryRepozitory(AppDbContext context) : base(context)
        {
		}
	}
}

