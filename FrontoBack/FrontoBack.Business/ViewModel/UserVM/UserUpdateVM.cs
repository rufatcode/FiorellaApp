using System;
using System.ComponentModel.DataAnnotations;

namespace FrontoBack.Business.ViewModel.UserVM
{
	public class UserUpdateVM
	{
		public string Id { get; set; }
		public string UserName { get; set; }
		public string FullName { get; set; }
		[EmailAddress,DataType(DataType.EmailAddress)]
		public string Email { get; set; }
		public bool Status { get; set; }
		public UserUpdateVM()
		{
		}
	}
}

