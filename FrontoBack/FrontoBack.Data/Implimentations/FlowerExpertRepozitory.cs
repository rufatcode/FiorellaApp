using System;
using FrontoBack.Core.Interfaces;
using FrontoBack.DAL;
using FrontoBack.Models;

namespace FrontoBack.Data.Implimentations
{
	public class FlowerExpertRepozitory:Repozitory<FlowerExpert>, IFlowerExpertRepozitory
    {
		public FlowerExpertRepozitory(AppDbContext context) : base(context)
        {
		}
	}
}

