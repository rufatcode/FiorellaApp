using System;
using FrontoBack.Models;
using Microsoft.AspNetCore.Identity;

namespace FrontoBack.Business.ViewModel.UserVM
{
	public class UserListVM
	{
		public string Id { get; set; }
		public string UserName { get; set; }
		public IList<string> Roles { get; set; }
		public UserListVM()
		{
		}
		
	}
}

