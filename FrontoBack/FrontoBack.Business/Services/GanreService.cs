using System;
using FrontoBack.Business.Interfaces;
using FrontoBack.Models;
using FrontoBack.ViewModel.GanreVM;

namespace FrontoBack.Business.Services
{
	public class GanreService:IGanreService
	{
		public GanreService()
		{
		}

        public Task<bool> Create(CreateGanreVM createGanreVM)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Ganre>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Ganre> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(UpdateGanreVM updateGanreVM)
        {
            throw new NotImplementedException();
        }
    }
}

