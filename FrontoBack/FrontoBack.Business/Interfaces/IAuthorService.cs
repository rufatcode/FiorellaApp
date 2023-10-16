using System;
using FrontoBack.Models;
using FrontoBack.ViewModel.AuthorVM;

namespace FrontoBack.Business.Interfaces
{
	public interface IAuthorService
	{
		Task<bool> Create(CreateAuthorVM  createAuthorVM);
		Task<bool> Delete(int id);
		Task<bool> Update(UpdateAuthorVM updateAuthorVM);
		Task<Author> GetById(int id);
		Task<List<Author>> GetAll();
	}
}

