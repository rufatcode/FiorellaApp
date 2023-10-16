using System;
using FrontoBack.Business.Interfaces;
using FrontoBack.Models;
using FrontoBack.ViewModel.CityVM;

namespace FrontoBack.Business.Services
{
    public class CityService : ICityService
    {
        public Task<bool> Create(CreateCityVM createCityVM)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<City>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<City> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(UpdateCityVM updateCityVM)
        {
            throw new NotImplementedException();
        }
    }
}

