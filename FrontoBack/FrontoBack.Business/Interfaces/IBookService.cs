using System;
using FrontoBack.Models;
using FrontoBack.ViewModel.AuthorVM;
using FrontoBack.ViewModel.BookVM;

namespace FrontoBack.Business.Interfaces
{
	public interface IBookService
	{
        Task<bool> Create(CreateBookVM  createBookVM);
        Task<bool> Delete(int id);
        Task<bool> Update(UpdateBookVM  updateBookVM);
        Task<Book> GetById(int id);
        Task<List<Book>> GetAll();
    }
}

