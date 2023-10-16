using System;
using FrontoBack.Models;
using FrontoBack.ViewModel.CountryVM;
using FrontoBack.ViewModel.GanreVM;

namespace FrontoBack.Business.Interfaces
{
	public interface IGanreService
	{
        Task<bool> Create(CreateGanreVM  createGanreVM);
        Task<bool> Delete(int id);
        Task<bool> Update(UpdateGanreVM  updateGanreVM);
        Task<Ganre> GetById(int id);
        Task<List<Ganre>> GetAll();
    }
}

