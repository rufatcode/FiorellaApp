using System;
using FrontoBack.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace FrontoBack.Models
{
	public class AppUser:IdentityUser
	{
		public string FullName { get; set; }
		public bool IsActive { get; set; }
		public List<Check> Checkes { get; set; }
		public AppUser()
		{
		}
	}
}

