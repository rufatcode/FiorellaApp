using System;
using System.ComponentModel.DataAnnotations;
using FrontoBack.Core.Interfaces;

namespace FrontoBack.Core.Models
{
	public class BaseEntity: IBaseEntity
    {
		public BaseEntity()
		{
		}
		[Key]
        public int Id { get; set; }
    }
}

