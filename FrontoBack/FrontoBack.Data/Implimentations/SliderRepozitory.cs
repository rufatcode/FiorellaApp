using System;
using FrontoBack.Core.Interfaces;
using FrontoBack.DAL;
using FrontoBack.Models;

namespace FrontoBack.Data.Implimentations
{
	public class SliderRepozitory:Repozitory<Slider>, ISliderRepozitory
    {
		public SliderRepozitory(AppDbContext context) : base(context)
        {
		}
	}
}

