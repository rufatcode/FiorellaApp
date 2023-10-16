using System;
using FrontoBack.Core.Interfaces;
using FrontoBack.DAL;
using FrontoBack.Models;

namespace FrontoBack.Data.Implimentations
{
	public class GanreRepozitory:Repozitory<Ganre>, IGanreRepozitory
    {
		public GanreRepozitory(AppDbContext context) : base(context)
        {
		}
	}
}

