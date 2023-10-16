using System;
using FrontoBack.Core.Interfaces;
using FrontoBack.DAL;
using FrontoBack.Models;

namespace FrontoBack.Data.Implimentations
{
	public class BlogRepozitory:Repozitory<Blog>, IBlogRepozitory
    {
		public BlogRepozitory(AppDbContext context) : base(context)
        {
		}
	}
}

