using System;
using FrontoBack.Core.Interfaces;
using FrontoBack.DAL;
using FrontoBack.Models;

namespace FrontoBack.Data.Implimentations
{
	public class CatagoryRepozitory:Repozitory<Catagorie>, ICatagoryRepozitory
    {
		public CatagoryRepozitory(AppDbContext context) : base(context)
        {
		}
	}
}

