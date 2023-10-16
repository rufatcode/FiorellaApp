using System;
using FrontoBack.Models;
using FrontoBack.ViewModel.GanreVM;
using FrontoBack.ViewModel.StreetVM;

namespace FrontoBack.Business.Interfaces
{
	public interface IStreetService
	{

        Task<bool> Create(CreateStreetVM  createStreetVM);
        Task<bool> Delete(int ?id);
        Task<bool> Update(int id,UpdateStreetVM  updateStreetVM);
        Task<Street> GetById(int? id);
        Task<Street> GetByIdThenIncludeCountry(int? id);
        Task<Street> GetByIdIncludeCity(int? id);
        Task<List<Street>> GetAll();

    }
}

