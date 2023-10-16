using System;
using FrontoBack.Business.Interfaces;
using FrontoBack.Core.Interfaces;
using FrontoBack.DAL;
using FrontoBack.Models;
using FrontoBack.ViewModel.AuthorVM;

namespace FrontoBack.Business.Services
{
	public class AuthorService:IAuthorService
	{
        private readonly AppDbContext _context;
        private readonly IAuthorRepozitory _authorRepozitory;
		public AuthorService(AppDbContext context)
		{
            _context = context;
		}

        public async Task<bool> Create(CreateAuthorVM createAuthorVM)
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("something went wrong");
            }
            
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Author>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Author> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(UpdateAuthorVM updateAuthorVM)
        {
            throw new NotImplementedException();
        }
    }
}

