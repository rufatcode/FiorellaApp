using System;
using FrontoBack.Core.Interfaces;
using FrontoBack.Models;

namespace FrontoBack.Data.Implimentations
{
	public class BlogRepozitory:Repozitory<Blog>, IBlogRepozitory
    {
		public BlogRepozitory()
		{
		}
	}
}

