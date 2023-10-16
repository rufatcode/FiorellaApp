using System;
using FrontoBack.Core.Interfaces;
using FrontoBack.DAL;
using FrontoBack.Models;

namespace FrontoBack.Data.Implimentations
{
	public class AuthorRepozitory:Repozitory<Author>, IAuthorRepozitory
    {
		public AuthorRepozitory(AppDbContext context) : base(context)
        {
		}
	}
}

