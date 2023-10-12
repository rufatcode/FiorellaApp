using System;
using FrontoBack.Core.Interfaces;
using FrontoBack.Models;

namespace FrontoBack.Data.Implimentations
{
	public class AuthorRepozitory:Repozitory<Author>, IAuthorRepozitory
    {
		public AuthorRepozitory()
		{
		}
	}
}

