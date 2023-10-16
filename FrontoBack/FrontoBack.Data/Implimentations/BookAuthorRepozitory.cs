using System;
using FrontoBack.Core.Interfaces;
using FrontoBack.DAL;
using FrontoBack.Models;

namespace FrontoBack.Data.Implimentations
{
	public class BookAuthorRepozitory:Repozitory<BookAuthor>, IBookAuthorRepozitory
    {
		public BookAuthorRepozitory(AppDbContext context) : base(context)
        {
		}
	}
}

