using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FrontoBack.Models;

namespace FrontoBack.Core.Models
{
	public class Check
    {
		[Key]
		public int Id { get; set; }
		public DateTime SaleTime { get; set; }
		public double TotalAmmount { get; set; }
		[ForeignKey(nameof(AppUser))]
		public string UserId { get; set; }
		public AppUser AppUser { get; set; }
		public List<CheckProduct> CheckProducts { get; set; }
		public Check()
		{
			CheckProducts = new();
		}
		
	}
}

