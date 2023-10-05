using System;
using System.ComponentModel.DataAnnotations;

namespace FrontoBack.ViewModel.AccountVM
{
	public class LoginVM
	{
		public string UserNameOrEmail { get; set; }
		[DataType(DataType.Password)]
		public string Password { get; set; }
		public bool Remember { get; set; }
		public LoginVM()
		{
		}
	}
}

