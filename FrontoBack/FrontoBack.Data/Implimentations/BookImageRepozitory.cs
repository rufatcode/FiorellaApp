using System;
using FrontoBack.Core.Interfaces;
using FrontoBack.DAL;
using FrontoBack.Models;

namespace FrontoBack.Data.Implimentations
{
	public class BookImageRepozitory:Repozitory<BookImages>, IBookImageRepozitory
    {
		public BookImageRepozitory(AppDbContext context) : base(context)
        {
		}
	}
}

