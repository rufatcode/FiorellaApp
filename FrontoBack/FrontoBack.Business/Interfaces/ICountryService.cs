using System;
using FrontoBack.Models;
using FrontoBack.ViewModel.CityVM;
using FrontoBack.ViewModel.CountryVM;

namespace FrontoBack.Business.Interfaces
{
	public interface ICountryService
	{
        Task<bool> Create(CreateCountryVM  createCountryVM);
        Task<bool> Delete(int id);
        Task<bool> Update(UpdateCountryVM  updateCountryVM);
        Task<Country> GetById(int id);
        Task<List<Country>> GetAll();
    }
}

