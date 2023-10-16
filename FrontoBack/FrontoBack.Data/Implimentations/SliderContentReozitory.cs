using System;
using FrontoBack.Core.Interfaces;
using FrontoBack.DAL;
using FrontoBack.Models;

namespace FrontoBack.Data.Implimentations
{
	public class SliderContentReozitory:Repozitory<SliderContent>, ISliderContentReozitory
    {
		public SliderContentReozitory(AppDbContext context) : base(context)
        {
		}
	}
}

