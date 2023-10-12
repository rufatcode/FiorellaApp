using System;
using System.ComponentModel.DataAnnotations.Schema;
using FrontoBack.Models;

namespace FrontoBack.Core.Models
{
	public class Check
    {
		public int Id { get; set; }
		public DateTime SaleTime { get; set; }
		[ForeignKey(nameof(AppUser))]
		public string UserId { get; set; }
		public AppUser AppUser { get; set; }
		public List<CheckProduct> CheckProducts { get; set; }
		
	}
}

