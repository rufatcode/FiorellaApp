using System;
using FrontoBack.Models;

namespace FrontoBack.Business.ViewModel.RoleVM
{
	public class DetailRoleVM
	{
		public string Role { get; set; }
		public IList<AppUser> Users { get; set; }
		public DetailRoleVM()
		{
		}
	}
}

