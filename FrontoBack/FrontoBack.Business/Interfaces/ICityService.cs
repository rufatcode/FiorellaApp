using System;
using FrontoBack.Models;
using FrontoBack.ViewModel.BookVM;
using FrontoBack.ViewModel.CityVM;

namespace FrontoBack.Business.Interfaces
{
	public interface ICityService
	{
        Task<bool> Create(CreateCityVM createCityVM);
        Task<bool> Delete(int id);
        Task<bool> Update(UpdateCityVM updateCityVM);
        Task<City> GetById(int id);
        Task<List<City>> GetAll();
    }
}

