using System;
using FrontoBack.Core.Interfaces;
using FrontoBack.DAL;
using FrontoBack.Models;

namespace FrontoBack.Data.Implimentations
{
	public class BookRepozitory:Repozitory<Book>, IBookRepozitory
    {
		public BookRepozitory(AppDbContext context) : base(context)
        {
		}
	}
}

