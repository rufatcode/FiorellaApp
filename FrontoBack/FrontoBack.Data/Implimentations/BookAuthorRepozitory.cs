using System;
using FrontoBack.Core.Interfaces;
using FrontoBack.Models;

namespace FrontoBack.Data.Implimentations
{
	public class BookAuthorRepozitory:Repozitory<BookAuthor>, IBookAuthorRepozitory
    {
		public BookAuthorRepozitory()
		{
		}
	}
}

