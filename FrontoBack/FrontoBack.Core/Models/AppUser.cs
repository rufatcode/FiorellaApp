using System;
using Microsoft.AspNetCore.Identity;

namespace FrontoBack.Models
{
	public class AppUser:IdentityUser
	{
		public string FullName { get; set; }
		public AppUser()
		{
		}
	}
}

