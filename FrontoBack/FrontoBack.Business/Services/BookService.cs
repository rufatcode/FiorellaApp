using System;
using FrontoBack.Business.Interfaces;
using FrontoBack.Models;
using FrontoBack.ViewModel.BookVM;

namespace FrontoBack.Business.Services
{
	public class BookService:IBookService
	{
		public BookService()
		{
		}

        public Task<bool> Create(CreateBookVM createBookVM)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Book>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(UpdateBookVM updateBookVM)
        {
            throw new NotImplementedException();
        }
    }
}

