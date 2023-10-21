using System;
namespace FrontoBack.Business.ViewModel.UserVM
{
	public class UserDetailVM
	{
		public string Id { get; set; }
		public string UserName { get; set; }
		public string FullName { get; set; }
		public string Email { get; set; }
		public bool IsActive { get; set; }
		public IList<string> Roles { get; set; }
		public bool IsVerified { get; set; }
		public UserDetailVM()
		{
		}
	}
}

