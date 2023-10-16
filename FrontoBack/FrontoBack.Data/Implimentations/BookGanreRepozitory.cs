using System;
using FrontoBack.Core.Interfaces;
using FrontoBack.DAL;
using FrontoBack.Models;

namespace FrontoBack.Data.Implimentations
{
	public class BookGanreRepozitory:Repozitory<BookGanre>, IBookGanreRepozitory
    {
		public BookGanreRepozitory(AppDbContext context) : base(context)
        {
		}
	}
}

