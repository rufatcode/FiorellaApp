using System;
using FrontoBack.Core.Interfaces;
using FrontoBack.DAL;
using FrontoBack.Models;

namespace FrontoBack.Data.Implimentations
{
	public class AccordionRepozitory:Repozitory<Accordion>, IAccordionRepozitory
    {
		public AccordionRepozitory(AppDbContext context):base(context)
		{
		}
	}
}

