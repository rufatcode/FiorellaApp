using System;
using FrontoBack.Core.Interfaces;
using FrontoBack.DAL;
using FrontoBack.Models;

namespace FrontoBack.Data.Implimentations
{
	public class StreetRepozitory:Repozitory<Street>, IStreetRepozitory
    {
		public StreetRepozitory(AppDbContext context):base(context)
		{
		}
	}
}

