using System;
using FrontoBack.Business.Interfaces;
using FrontoBack.Models;
using FrontoBack.ViewModel.CountryVM;

namespace FrontoBack.Business.Services
{
	public class CountryService: ICountryService
    {
		public CountryService()
		{
		}

        public Task<bool> Create(CreateCountryVM createCountryVM)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Country>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Country> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(UpdateCountryVM updateCountryVM)
        {
            throw new NotImplementedException();
        }
    }
}

