using System;
using FrontoBack.Core.Interfaces;
using FrontoBack.Models;

namespace FrontoBack.Data.Implimentations
{
	public class BookRepozitory:Repozitory<Book>, IBookRepozitory
    {
		public BookRepozitory()
		{
		}
	}
}

